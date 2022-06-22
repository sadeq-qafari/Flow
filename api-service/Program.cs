using Meteor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Api;
using Saanaa.Core.AspNetCore;
using Saanaa.Core.AspNetCore.Extensions;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StartupCoreExtensions.LoadSaanaaServiceConfigs(
                EnvVars.Get("CONNECTION_STRING")!,
                EnvVars.Get("SERVICE_NAME")!);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .MinimumLevel.Override("System", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.WithProperty("Service", EnvVars.Get("SERVICE_NAME"))
                .Enrich.WithExceptionDetails()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 512 * 1024 * 1024,
                    retainedFileCountLimit: 1,
                    outputTemplate:
                    "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureAppConfiguration(x => x.AddJsonFile("ocelot.json"))
                        .UseStartup<Startup>()
                        .UseSerilog()
                        .UseUrls(ServiceConfig.Get("base_url"));
                });
    }
}
