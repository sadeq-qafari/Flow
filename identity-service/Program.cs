using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Core.AspNetCore;
using Core.AspNetCore.Extensions;
using Serilog;
using Serilog.Events;

namespace Identity
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Log.Logger = Meteor.Logger.DefaultLogger.Config("Identity")
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("System", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Verbose)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Verbose)
                .CreateLogger();
            Log.Debug("app is starting");
            StartupCoreExtensions.LoadSqServiceConfigs(
                Environment.GetEnvironmentVariable("CONNECTION_STRING")!,
                Environment.GetEnvironmentVariable("SERVICE_NAME")!);
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls(ServiceConfig.Get("base_url"));
                });
    }
}
