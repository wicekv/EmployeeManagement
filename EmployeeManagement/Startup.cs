using EmployeeManagement.DTO;
using EmployeeManagement.DTO.Validators;
using EmployeeManagement.Middleware;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddFluentValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeManagement", Version = "v1" });
            });
            services.AddDbContext<DbEmployeeManagementContext>();
            services.AddScoped<DbInitializer>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<RequestTimeMiddleware>();
            services.AddScoped<IValidator<RegisterBossDTO>, RegisterBossDtoValidator>();
            services.AddScoped<IValidator<RegisterEmployeeDTO>, RegisterEmployeeDtoValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbInitializer dbInitializer)
        {
            dbInitializer.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeManagement v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestTimeMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
