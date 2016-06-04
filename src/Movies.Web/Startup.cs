using Microsoft.AspNet.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.DotnetCore;
using Movies.DotnetCore.Interfaces;

namespace Movies.Web
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json").AddEnvironmentVariables().Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var path = _configuration["Data:FilePath"];
            services.AddSingleton(provider => _configuration);
            services.AddTransient<HttpWrapper, HttpWrapper>();
            //services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IMovieRepository>(provider => new StaticMovieRepository(path));
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
