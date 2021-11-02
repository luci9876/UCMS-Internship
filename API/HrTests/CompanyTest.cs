using HrApi.Controllers;
using HrApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace HrApi.Tests
{
    public class CompanyTest
    {

        //private readonly HrContext _context;
        //private static DbContextOptions<HrContext> CreateInMemmoryDbContextOptions([CallerMemberName] string dbName=null) 
        //{
        //    return new DbContextOptionsBuilder<HrContext>()
        //        .UseInMemoryDatabase(databaseName: dbName)
        //        .Options;
        //}
        //private async Task ExecuteActionAsync(Func<HrContext, Task> action, [CallerMemberName] string dbName = null) 
        //{
        //    using var context = new HrContext(CreateInMemmoryDbContextOptions(dbName));
        //    await action(context);
        //    await context.SaveChangesAsync();
        //}
        //private async Task VerifyActionAsync(Func<HrContext, Task> action, [CallerMemberName] string dbName = null)
        //{
        //    using var context = new HrContext(CreateInMemmoryDbContextOptions(dbName));
        //    await action(context);
            
        //}
        //private async Task SeedMockData(HrContext context) 
        //{
        //    await context.AddAsync(new Company { Id = 1, Name = "UCMS", Description = "Companie specializată în soluții de management a resurselor umane" });
        //}
        //private CompaniesController SetupCompaniesController(HrContext context) 
        //{
        //    return new CompaniesController(context);
        //}
        //public CompanyTest()
        //{
        //    var serviceProvider = new ServiceCollection()
        //        .AddEntityFrameworkInMemoryDatabase()
        //        .BuildServiceProvider();

        //    //var builder = new DbContextOptionsBuilder<HrContext>()
        //    //    .UseInMemoryDatabase("HrAppDB")
        //    //    .UseInternalServiceProvider(serviceProvider);

        //    //_context = new HrContext(builder.Options);
        //    //_context.Companies.Add(new Company { Id = 1, Name = "UCMS", Description = "Companie specializată în soluții de management a resurselor umane" });
        //    //_context.SaveChanges();
        //}

        //[Fact]
        //public async Task GetAllCompanies()
        //{
        //    await ExecuteActionAsync(async ctx => await SeedMockData(ctx));
        //    await VerifyActionAsync(async ctx =>
        //    {
        //        //var controller = new CompaniesController(ctx);
        //        //var result = await controller.GetCompanies();
        //        //Assert.Single(result.Value);
        //    });
        //}

        //[Fact]
        //public async Task GetCompanyById_InvalidId()
        //{
        //    await ExecuteActionAsync(async ctx => await SeedMockData(ctx));
        //    await VerifyActionAsync(async ctx =>
        //    {
        //        var controller = new CompaniesController(ctx);
        //        var result = await controller.GetCompany(99);
        //        Assert.IsType<NotFoundResult>(result.Result);
        //    });
        //}

        //[Fact]
        //public async Task GetCompanyById_ValidId()
        //{
        //    await ExecuteActionAsync(async ctx => await SeedMockData(ctx));
        //    await VerifyActionAsync(async ctx =>
        //    {
        //        var controller = new CompaniesController(ctx);
        //        var result = await controller.GetCompany(1);
        //        Assert.IsType<OkObjectResult>(result.Result);
        //    });
        //}

        //[Fact]
        //public async Task CreateCompany_ReturnsBadRequest_WhenModelStateIsInvalid()
        //{
        //    await ExecuteActionAsync(async ctx => await SeedMockData(ctx));
        //    await VerifyActionAsync(async ctx =>
        //    {
        //        var controller = new CompaniesController(ctx);
        //        controller.ModelState.AddModelError("Name", "Required");
        //        var result = await controller.PostCompany(new Company());
        //        Assert.IsType<BadRequestObjectResult>(result.Result);
        //    });
        //}

        //[Fact]
        //public async Task CreateCompany_ReturnsNewlyCreatedCompany()
        //{
        //    await ExecuteActionAsync(async ctx => await SeedMockData(ctx));
        //    await VerifyActionAsync(async ctx =>
        //    {
        //        var controller = new CompaniesController(ctx);
        //        var result = await controller.PostCompany(new Company { Name = "AROBS", Description = "un furnizor global de soluții IT și software personalizat bazat pe cele mai noi tehnologii" });
        //        Assert.IsType<CreatedAtActionResult>(result.Result);
        //    });
        //}

        //[Fact]
        //public async Task EditCompany_ReturnsBadRequest_WhenModelStateIsInvalid()
        //{
        //    await ExecuteActionAsync(async ctx => await SeedMockData(ctx));
        //    await VerifyActionAsync(async ctx =>
        //    {
        //        var controller = new CompaniesController(ctx);
        //        controller.ModelState.AddModelError("Name", "Required");
        //        var result = await controller.PutCompany(1, new Company { Id = 2, Description = "description" });
        //        Assert.IsType<BadRequestObjectResult>(result);
        //    });
        //}

        //[Fact]
        //public async Task EditCompany_ReturnsBadRequest_WhenIdIsInvalid()
        //{
        //    await ExecuteActionAsync(async ctx => await SeedMockData(ctx));
        //    await VerifyActionAsync(async ctx =>
        //    {
        //        var controller = new CompaniesController(ctx);
        //        var result = await controller.PutCompany(99, new Company { Id = 99, Name = "company", Description = "description" });
        //        Assert.IsType<NotFoundResult>(result);
        //    });
        //}

        //[Fact]
        //public async Task EditCompany_ReturnsNoContent_WhenCompanyIsUpdated()
        //{
        //    await ExecuteActionAsync(async ctx => await SeedMockData(ctx));
        //    await VerifyActionAsync(async ctx =>
        //    {
        //        var controller = new CompaniesController(ctx);
        //        var result = await controller.PutCompany(1, new Company { Id = 1, Name = "NewCompany" });
        //        var getResult = await controller.GetCompany(1);
        //        Assert.Equal("NewCompany", ((getResult.Result as OkObjectResult).Value as Company).Name);
        //        Assert.IsType<NoContentResult>(result);
        //    });
        //}

        //[Fact]
        //public async Task DeleteCompany_ReturnsNotFound_WhenIdIsInvalid()
        //{
        //    await ExecuteActionAsync(async ctx => await SeedMockData(ctx));
        //    await VerifyActionAsync(async ctx =>
        //    {
        //        var controller = new CompaniesController(ctx);
        //        var result = await controller.DeleteCompany(99);
        //        Assert.IsType<NotFoundResult>(result);
        //    });
        //}

        //[Fact]
        //public async Task DeleteCompany_ReturnsNoContent_WhenCompanyIsDeleted()
        //{
        //    await ExecuteActionAsync(async ctx => await SeedMockData(ctx));
        //    await VerifyActionAsync(async ctx =>
        //    {
        //        var controller = new CompaniesController(ctx);
        //        var result = await controller.DeleteCompany(1);
        //        Assert.IsType<NoContentResult>(result);
        //    });
        //}
    }
}
