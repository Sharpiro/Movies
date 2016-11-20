using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Microsoft.AspNet.Builder
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomFileServer(this IApplicationBuilder app, IHostingEnvironment env, string directoryName)
        {
            var path = Path.Combine(env.ContentRootPath, directoryName);
            var options = new StaticFileOptions { FileProvider = new PhysicalFileProvider(path), RequestPath = new PathString($"/{directoryName}") };
            app.UseStaticFiles(options);
            return app;
        }
    }
}
