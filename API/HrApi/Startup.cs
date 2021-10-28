using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HrApi.Models;
using Microsoft.OpenApi.Models;
using HrApi.Extensions;
using HrApi.Services;
using HrApi.ActionFilters;
using AutoMapper;
using HrApi.Mapper;
using HrApi.Services.Interfaces;
using HrApi.Repositories.Interfaces;
using HrApi.Repositories;
using HrApi.Sorting;
using HrApi.Sorting.Interfaces;
using HrApi.Data.Repositories.Interfaces;
using HrApi.Data.Repositories;
using HrApi.Data.Models.Helpers.Interfaces;
using HrApi.Data.Models.Helpers;
using HrApi.Data.Models.Interfaces;
using HrApi.Data.Models;
using HrApi.BussinessLogic.Services.Interfaces;

namespace HrApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);
            //services.AddControllers(config =>
            ///{
            // config.RespectBrowserAcceptHeader = true;
            //config.ReturnHttpNotAcceptable = true;
            //}).AddXmlDataContractSerializerFormatters().AddNewtonsoftJson();
            services.AddControllers();
            services.AddDbContext<HrContext>(ServiceLifetime.Transient);
            services.AddAuthentication();
            services.AddIdentityService();
            services.AddJwtToken(Configuration);

            services.AddScoped<ISortHelper<Company>, SortHelper<Company>>();

            services.AddScoped<IDataShaper<Company>, DataShaper<Company>>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddScoped<IMail, Mail>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IImageRepository, ImageRepository>();

            

            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ISortingCompanies, SortingCompanies>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IImageService, ImageService>();
            

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
            }
            app.UseMiddleware<CustomExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(policy => policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:4200"));
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}