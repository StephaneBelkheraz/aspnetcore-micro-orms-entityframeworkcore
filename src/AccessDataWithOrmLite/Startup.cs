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
using System.IO;
using System.Data;
using ServiceStack.OrmLite;
using AccessDataWithOrmLite.Models;
using ServiceStack.Data;

namespace AccessDataWithOrmLite
{
    public class Startup
    {
        // Example with CookBookRepository and ICookBookRepositoryCrud option 2
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        // for all code exept option 3
        //public IConfigurationRoot Configuration { get; }

        // option3
        public static IConfigurationRoot Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Example with CookBookRepository

            //services.AddScoped<IDbConnection>
            //  (connectionFactory => new OrmLiteConnectionFactory(
            //    Configuration.GetConnectionString("DbConnection"),
            //        SqlServer2012Dialect.Provider).OpenDbConnection());
            //services.AddScoped<ICookBookRepository, CookBookRepository>();

            #endregion

            #region Example with ICookBookRepositoryCrud option 1

            //services.Add(new ServiceDescriptor(typeof(IConfiguration),
            //         provider => new ConfigurationBuilder()
            //                        .SetBasePath(Directory.GetCurrentDirectory())
            //                        .AddJsonFile("appsettings.json",
            //                                     optional: false,
            //                                     reloadOnChange: true)
            //                        .Build(),
            //         ServiceLifetime.Singleton));         
            //services.AddScoped<ICookBookRepositoryCrud, CookBookRepositoryCrud>();

            #endregion

            #region Example with ICookBookRepositoryCrud  option 2, we manage here the IDbConnectionFactory lifecycle

            //services.AddSingleton<IDbConnection>(
            //    new OrmLiteConnectionFactory(Configuration.GetConnectionString("DbConnection"), SqlServer2012Dialect.Provider)
            //            .OpenDbConnection());

            //services.AddScoped<ICookBookRepositoryCrud, CookBookRepositoryCrud>();

            #endregion

            #region Example with ICookBookRepositoryCrud  option 3, we don't manage here the IDbConnectionFactory lifecycle

            services.AddScoped<ICookBookRepositoryCrud, CookBookRepositoryCrud>();

            #endregion

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
