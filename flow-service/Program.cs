using System;
using Core.AspNetCore;
using Core.AspNetCore.Extensions;
using Core.AspNetCore.Logger;
using Meteor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Flow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load Service Configurations
            StartupCoreExtensions.LoadSqServiceConfigs(
                EnvVars.Get("CONNECTION_STRING")!,
                EnvVars.Get("SERVICE_NAME")!);

            // Configure System Log
            Log.Logger = CoreLogger.CreateCoreLogger();

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
