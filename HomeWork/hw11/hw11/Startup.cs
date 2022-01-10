using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hw10.Infrastructure;
using hw10.Models;
using hw11.Infrastructure;
using hw11.Infrastructure.Interfaces;
using hw9.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace hw11
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
            services.AddRazorPages();
            services.AddLogging();

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

            services.AddScoped<IExceptionHandler, ExceptionHandler>();
            services.AddScoped<DynamicCalculatorVisitor>();
            services.AddScoped<ICalculatorVisitor, CachingCalculatorVisitor>(provider =>
                new CachingCalculatorVisitor(provider.GetRequiredService<DynamicCalculatorVisitor>(),
                    provider.GetRequiredService<ApplicationContext>()));
            services.AddTransient<ICalculator, Calculator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}