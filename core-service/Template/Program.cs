using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Saanaa.Core.AspNetCore;
using Saanaa.Core.AspNetCore.CoreExtensions;

namespace %NAMESPACE%
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StartupCoreExtensions.LoadSaanaaServiceConfigs(
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
