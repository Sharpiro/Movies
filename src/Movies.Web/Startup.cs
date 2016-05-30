﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Movies.DotnetCore;

namespace Movies.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<HttpWrapper, HttpWrapper>();
            services.AddTransient<MovieApiHelper, MovieApiHelper>();
            services.AddTransient<MovieBusinessLayer, MovieBusinessLayer>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseMvc(rb =>
            {
                rb.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                rb.MapRoute("defaultApi", "api/{controller}/{action}/{id?}");
            });
            app.UseFileServer();
        }
    }
}