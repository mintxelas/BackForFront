using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace FrontApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddUserSecrets<Startup>().AddEnvironmentVariables().AddCommandLine(args).Build();
            var startup = new Startup(configuration);
            var builder = WebApplication.CreateSlimBuilder();
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
