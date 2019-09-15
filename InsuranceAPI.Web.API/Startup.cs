using InsuranceAPI.Models.Context;
using InsuranceAPI.Interfaces;
using InsuranceAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InsuranceAPI.Maps;
using InsuranceAPI.Services;
using Newtonsoft.Json.Serialization;

namespace InsuranceAPI.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationDBContext>(
                options => options.UseSqlServer(_config.GetConnectionString("InsuranceDBConnection"), b => b.MigrationsAssembly("InsuranceAPI.Web.API")));

            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                    var resolver = options.SerializerSettings.ContractResolver;

                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                });

            //services.AddScoped<IInsuranceRepository, MockInsuranceRepository>();
            services.AddScoped<IInsuranceRepository, SQLInsuranceRepository>();
            services.AddScoped<IInsuranceService, InsuranceService>();
            services.AddScoped<IInsuranceMap, InsuranceMap>();

            //services.AddScoped<ICustomerRepository, MockCustomerRepository>();
            services.AddScoped<ICustomerRepository, SQLCustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerMap, CustomerMap>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseMvc();
        }
    }
}
