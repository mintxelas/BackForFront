using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace InternalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddUserSecrets<Startup>().AddEnvironmentVariables().AddCommandLine(args).Build();
            var builder = WebApplication.CreateSlimBuilder();
            var startup = new Startup(configuration, builder.Environment);
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
