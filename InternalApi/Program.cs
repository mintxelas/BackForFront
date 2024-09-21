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
            builder.AddServiceDefaults();
            builder.WebHost.UseKestrelHttpsConfiguration();
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            startup.Configure(app, app.Environment);
            app.Run();
        }
    }
}
