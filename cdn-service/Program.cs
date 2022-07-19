using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Dapper;
using Meteor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Core.AspNetCore;
using Core.AspNetCore.Extensions;

namespace Cdn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (EnvVars.Get<string>("COPY_OLD_CDN_FILES")?.ToLowerInvariant() == "true")
            {
                Console.WriteLine("================ Copying Old Files To New CDN ================");

                using (var connection =
                    new SqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
                {
                    while (true)
                    {
                        CultureInfo.CurrentCulture = new CultureInfo("en-US");
                        var files = connection.Query("SELECT TOP 100 * FROM [File].[Attachment] WHERE IsCopied=0").ToList();
                        if (files.Count <= 0) break;

                        Console.WriteLine($"Fetched {files.Count} new files");
                        foreach (var file in files)
                        {
                            var srcFile = Path.Combine(Environment.GetEnvironmentVariable("OLD_CDN_DIR"), file.FullPath);
                            if (!File.Exists(srcFile))
                            {
                                connection.Execute("UPDATE [File].[Attachment] SET IsDeleted=1, IsCopied=1 WHERE Id=@Id",
                                    new {file.Id});
                                continue;
                            }

                            var destDir = $"files/{file.TenantId ?? 0}/{file.UploadDate:yyyy/MM/dd}";
                            Directory.CreateDirectory(destDir);
                            var fileName = Path.Combine(destDir, GetUniqueCleanFileName(file.Title));

                            Console.WriteLine($"Copying to '{fileName}'");

                            File.Copy(srcFile, fileName, true);
                            connection.Execute("UPDATE [File].[Attachment] SET IsCopied=1,Description = @FileName WHERE Id=@Id", new {file.Id,FileName=fileName});
                        }
                    }

                    Console.WriteLine("\n\n\n\n================ Copying Old Files To New CDN Done! ================");
                }
            }

            StartupCoreExtensions.LoadSqServiceConfigs(
                Environment.GetEnvironmentVariable("CONNECTION_STRING")!,
                Environment.GetEnvironmentVariable("SERVICE_NAME")!);

            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls(ServiceConfig.Get("base_url"));
                }).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static string GetUniqueCleanFileName(string fileName, string suffix = "")
        {
            var ext = Path.GetExtension(fileName);
            fileName = CleanFileName(Path.GetFileNameWithoutExtension(fileName));
            return $"{fileName}{suffix}{ext}";
        }

        private static string CleanFileName(string filename)
        {
            var invalidChars = System.IO.Path.GetInvalidFileNameChars();
            return string.Join("-", filename.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries))
                .Replace(' ', '-')
                .ToLowerInvariant()
                .TrimEnd('.');
        }
    }
}
