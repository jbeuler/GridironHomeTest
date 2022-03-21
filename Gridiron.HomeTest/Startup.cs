using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gridiron.HomeTest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Gridiron.HomeTest
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ApplicationAPI", Version = "v1" });
            });

            services.AddDbContext<ApplicationContext>(options =>
                options.UseInMemoryDatabase("gridiron_apps")
            );

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var UIEndpoint = Environment.GetEnvironmentVariable("UI_ENDPOINT");

            Console.WriteLine(UIEndpoint);

            app.UseCors(options => options.WithOrigins(UIEndpoint).AllowAnyMethod().AllowAnyHeader());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApplicationAPI v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationContext>();

            AddTestData(context);
        }

        private static void AddTestData(ApplicationContext context)
        {
            var testApplication1 = new Application
            {
                Name = "Application 1",
                EffectiveDate = DateTime.Parse("2022-07-01"),
                AddressStreet = "140 E 46th St",
                AddressCity = "New York",
                AddressState = "NY",
                AddressZip = "10017",
                InsuredValueAmount = 100000
            };

            var testApplication2 = new Application
            {
                Name = "Application 2",
                EffectiveDate = DateTime.Parse("2022-02-14"),
                AddressStreet = "461 NW 9th St",
                AddressCity = "Miami",
                AddressState = "FL",
                AddressZip = "33136",
                InsuredValueAmount = 185000
            };

            var testApplication3 = new Application
            {
                Name = "Application 3",
                EffectiveDate = DateTime.Parse("2022-02-15"),
                AddressStreet = "501 77th St",
                AddressCity = "Miami Beach",
                AddressState = "FL",
                AddressZip = "33141",
                InsuredValueAmount = 250000
            };

            context.Applications.Add(testApplication1);
            context.Applications.Add(testApplication2);
            context.Applications.Add(testApplication3);

            context.SaveChanges();
        }
    }
}
