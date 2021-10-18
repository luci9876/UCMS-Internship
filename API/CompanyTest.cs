using HrApi.Controllers;
using HrApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HrApi.Tests
{
    public class CompanyTest
    {

        private readonly HrContext _context;

        public CompanyTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<HrContext>()
                .UseInMemoryDatabase("CompanyDB")
                .UseInternalServiceProvider(serviceProvider);

            _context = new HrContext(builder.Options);

            _context.Companies.Add(new Company { Id = 1, Name = "UCMS", Description = "Companie specializată în soluții de management a resurselor umane" });

            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAllCompanies()
        {
            //arrange
            var controller = new CompaniesController(_context);

            //act
            var result = await controller.GetCompanies();

            //assert
            var model = Assert.IsAssignableFrom<IEnumerable<Company>>(result);
            Assert.Single(model);
        }

        [Fact]
        public async Task GetCompanyById_InvalidId()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.GetCompany(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetCompanyById_ValidId()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.GetCompany(1);

            var objectResult = Assert.IsType<ObjectResult>(result);
            var task = Assert.IsAssignableFrom<Company>(objectResult.Value);

            Assert.Equal("UCMS", task.Name);
        }

        [Fact]
        public async Task CreateCompany_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var controller = new CompaniesController(_context);
            controller.ModelState.AddModelError("Name", "Required");

            var result = await controller.PostCompany(new Company());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CreateCompany_ReturnsNewlyCreatedCompany()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.PostCompany(new Company { Name = "AROBS" });

            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task EditCompany_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var controller = new CompaniesController(_context);
            controller.ModelState.AddModelError("Name", "Required");

            var result = await controller.PutCompany(1, new Company { Id = 1, Name = "AROBS" });

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task EditCompany_ReturnsBadRequest_WhenIdIsInvalid()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.PutCompany(99, new Company { Id = 99, Name = "company", Description = "description" });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditCompany_ReturnsNoContent_WhenCompanyIsUpdated()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.PutCompany(1, new Company { Id = 1, Name = "company" });

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteCompany_ReturnsNotFound_WhenIdIsInvalid()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.DeleteCompany(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteCompany_ReturnsNoContent_WhenCompanyIsDeleted()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.DeleteCompany(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
