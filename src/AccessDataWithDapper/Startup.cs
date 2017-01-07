using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using AccessDataWithDapper.Models;
using System.IO;

namespace AccessDataWithDapper
{
    public class Startup
    {
        // Example with CookBookRepository
        //public Startup(IHostingEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    Configuration = builder.Build();
        //}

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Example with CookBookRepository
            //services.AddScoped<IDbConnection>
            //       (connection => new SqlConnection(
            //                Configuration.GetConnectionString("DbConnection")));
            //services.AddScoped<ICookBookRepository, CookBookRepository>();

            // Example with ICookBookRepositoryCrud
            services.Add(new ServiceDescriptor(typeof(IConfiguration),
                     provider => new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json",
                                                 optional: false,
                                                 reloadOnChange: true)
                                    .Build(),
                     ServiceLifetime.Singleton));
            services.AddScoped<ICookBookRepositoryCrud, CookBookRepositoryCrud>();


            // Add Mvc service
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
