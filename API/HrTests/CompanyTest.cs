using HrApi.Controllers;
using HrApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

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
                .UseInMemoryDatabase("HrAppDB")
                .UseInternalServiceProvider(serviceProvider);

            _context = new HrContext(builder.Options);
            _context.Companies.Add(new Company { Id = 1, Name = "UCMS", Description = "Companie specializată în soluții de management a resurselor umane" });
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAllCompanies()
        {
            var controller = new CompaniesController(_context);
            var result = await controller.GetCompanies();
            Assert.Single(result.Value);
        }

        [Fact]
        public async Task GetCompanyById_InvalidId()
        {
            var controller = new CompaniesController(_context);
            var result = await controller.GetCompany(99);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetCompanyById_ValidId()
        {
            var controller = new CompaniesController(_context);
            var result = await controller.GetCompany(1);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task CreateCompany_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var controller = new CompaniesController(_context);
            controller.ModelState.AddModelError("Name", "Required");
            var result = await controller.PostCompany(new Company());
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task CreateCompany_ReturnsNewlyCreatedCompany()
        {
            var controller = new CompaniesController(_context);
            var result = await controller.PostCompany(new Company { Name = "AROBS" ,Description= "un furnizor global de soluții IT și software personalizat bazat pe cele mai noi tehnologii" });
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public async Task EditCompany_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var controller = new CompaniesController(_context);
            controller.ModelState.AddModelError("Name", "Required");
            var result = await controller.PutCompany(1, new Company { Id = 2, Description="description" });
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
            var result = await controller.PutCompany(1, new Company { Id=1, Name = "NewCompany" });
            var getResult = await controller.GetCompany(1);
            Assert.Equal("NewCompany",getResult.Value.Name);
            Assert.IsType<NoContentResult>(result);
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
