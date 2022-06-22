using System;
using Meteor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Saanaa.Core.AspNetCore;
using Saanaa.Core.AspNetCore.Extensions;
using Saanaa.Core.AspNetCore.Logger;
using Serilog;

namespace Flow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load Service Configurations
            StartupCoreExtensions.LoadSaanaaServiceConfigs(
                EnvVars.Get("CONNECTION_STRING")!,
                EnvVars.Get("SERVICE_NAME")!);

            // Configure System Log
            Log.Logger = SaanaaLogger.CreateSaanaaLogger();

            try
            {
                Log.Debug("app is starting");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "app terminated unexpectedly!");
            }
            finally
            {
                Log.Information("good bye");
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseSerilog()
                        .UseUrls(ServiceConfig.Get("base_url"));
                });
    }
}
