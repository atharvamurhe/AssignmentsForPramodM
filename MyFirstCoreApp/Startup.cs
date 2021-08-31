using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreApp
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Added dependency for MVC service
            services.AddMvc(); //Adds all the features like Web API, MVC, and Razor Pages.
            //services.AddControllersWithViews(); //Adds all the features provided by AddMvc() but does not support Razor Pages
            //services.AddControllers();  //Adds Features required for API and MVC But excludes features like Views and Razor Pages.
            //services.AddRazorPages(); //Adds Features required for Razor pages like Controller and Model Binding but does not support Web API CORS(Cross Domain method calling)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                //Added MVC middleware to the Request Processing Pipeline
                //Calls index action from home controller as 'MapDefaultControllerRoute' has home as default controller and index as default action
                endpoints.MapDefaultControllerRoute();  

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World! " + _config["MyKey"] + "\n");
                //    //await context.Response.WriteAsync("Worker Process Name : " + System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                //});
            });

            //Example 1
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is First middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("This is First middleware response\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is second middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("This is second middleware response\n");
            //});
            //Output:
            //This is First middleware request
            //This is Second middleware request

            //Example 2
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is First middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("This is First middleware response\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is second middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("This is second middleware response\n");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("This is from run\n");
            //});
            //Output:
            //This is First middleware request
            //This is second middleware request
            //This is from run
            //This is second middleware response
            //This is First middleware response

            //Example 3
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is First middleware request\n");
            //    await context.Response.WriteAsync("This is First middleware response\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is second middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("This is second middleware response\n");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("This is from run\n");
            //});
            //Output:
            //This is First middleware request
            //This is First middleware response

            //Example 4
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is First middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("This is First middleware response\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is second middleware request\n");
            //    await context.Response.WriteAsync("This is second middleware response\n");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("This is from run\n");
            //});
            //Output:
            //This is First middleware request
            //This is second middleware request
            //This is second middleware response
            //This is First middleware response

            //Example 5
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is First middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("This is First middleware response\n");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("This is from run\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is second middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("This is second middleware response\n");
            //});
            //Output:
            //This is First middleware request
            //This is from run
            //This is First middleware response

            //Example 6
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is First middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("This is First middleware response\n");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("This is from run 1\n");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("This is from run 2\n");
            //});
            //Output:
            //This is First middleware request
            //This is from run 1
            //This is First middleware response

            //Example 7
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World! " + _config["MyKey"] + "\n");
            //        //await context.Response.WriteAsync("Worker Process Name : " + System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            //    });
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("This is First middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("This is First middleware response\n");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("This is from run 1\n");
            //});
            //Output:
            //Hello World! My First Key In Core Application.
        }
    }
}
