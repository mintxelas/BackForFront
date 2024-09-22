using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Idsrv4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var startup = new Startup();
            var builder = WebApplication.CreateSlimBuilder(args);
            startup.ConfigureServices(builder.Services);
            builder.AddServiceDefaults();
            builder.WebHost.UseKestrelHttpsConfiguration();
            var app = builder.Build();
            startup.Configure(app, app.Environment);
            app.MapDefaultEndpoints();
            app.Run();
        }
    }
}
