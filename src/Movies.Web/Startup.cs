using Microsoft.AspNet.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Movies.DotnetCore;
using Movies.DotnetCore.Interfaces;

namespace Movies.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<HttpWrapper, HttpWrapper>();
            services.AddTransient<MovieApiHelper, MovieApiHelper>();
            services.AddTransient<IMovieBusinessLayer, FakeMovieBusinessLayer>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseMvc(rb =>
            {
                //rb.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                rb.MapRoute("defaultApi", "api/{controller}/{action}/{id?}");
            });
            app.UseFileServer();
            app.UseCustomFileServer(env, "node_modules");
        }
    }
}
