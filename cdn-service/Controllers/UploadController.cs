using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cdn.Models;
using Core.AspNetCore.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Cdn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        [NeedPermission]
        public IActionResult UploadFiles()
        {
            var destDir = GetTodayDirectory(HttpContext.UserInfo()?.TenantId);
            Directory.CreateDirectory(destDir);
            var results = new List<FileUploadResult>();
            foreach (var file in Request.Form.Files)
            {
                var result = new FileUploadResult
                {
                    FileName = file.FileName,
                    Url = null
                };
                results.Add(result);

                if (!IsValidFile(file))
                    continue;

                try
                {
                    var fileName = Path.Combine(destDir, GetUniqueCleanFileName(file.FileName));
                    using var fs = System.IO.File.Open(fileName, FileMode.Create);
                    file.CopyTo(fs);
                    fs.Close();
                    result.Url = GetRelativeDownloadUrl(fileName);
                }
                catch
                {
                    // ignored
                }
            }

            return Ok(results);
        }

        [HttpPost("image")]
        [NeedPermission]
        public IActionResult UploadImages([FromForm] ImageUploadInDto model)
        {
            var defaultSizes = new List<ImageSizeDto>()
            {
                new ImageSizeDto
                {
                    Width = 1280,
                    Height = 0,
                    Suffix = "-lg"
                },
                new ImageSizeDto
                {
                    Width = 720,
                    Height = 0,
                    Suffix = "-md"
                },
                new ImageSizeDto
                {
                    Width = 480,
                    Height = 0,
                    Suffix = "-sm"
                },
                new ImageSizeDto
                {
                    Width = 320,
                    Height = 0,
                    Suffix = "-xs"
                }
            };
            var dir = GetTodayDirectory(HttpContext.UserInfo()?.TenantId);
            Directory.CreateDirectory(dir);
            var results = new List<ImageUploadResult>();
            foreach (var file in Request.Form.Files)
            {
                var result = new ImageUploadResult
                {
                    FileName = file.FileName,
                    Urls = new List<string>()
                };
                results.Add(result);

                if (!IsValidImage(file))
                    continue;

                try
                {
                    var fileName = Path.Combine(dir, GetUniqueCleanFileName(file.FileName));
                    using var fs = System.IO.File.Open(fileName, FileMode.Create);
                    file.CopyTo(fs);
                    fs.Seek(0, SeekOrigin.Begin);
                    using var image = Image.Load(fs);
                    fs.Close();
                    result.Urls.Add(GetRelativeDownloadUrl(fileName));

                    var sizes = GetImageSizesFromString(model.Sizes) ?? defaultSizes;
                    var utcNow = DateTime.UtcNow;
                    foreach (var size in sizes)
                    {
                        using var newImage = image.Clone(x => x.Resize(size.Width, size.Height));
                        fileName = Path.Combine(dir, GetUniqueCleanFileName(file.FileName, size.Suffix, utcNow));
                        newImage.Save(fileName);
                        result.Urls.Add(GetRelativeDownloadUrl(fileName));
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return Ok(results);
        }

        private static List<ImageSizeDto>? GetImageSizesFromString(string? str)
        {
            try
            {
                return str?
                    .Trim()
                    .Split(',')
                    .Select(size => size
                        .Trim()
                        .Split('x'))
                    .Select(wh => new ImageSizeDto
                    {
                        Width = int.Parse(wh[0]),
                        Height = int.Parse(wh[1]),
                        Suffix = $"-{wh[0]}x{wh[1]}"
                    })
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        private static string GetRelativeDownloadUrl(string fileName)
        {
            var fileNameFullPath = Path.GetFullPath(fileName);
            var filesDirectoryFullPath = Path.GetFullPath("files");

            return fileNameFullPath.Replace(filesDirectoryFullPath, "").Replace('\\', '/').TrimStart('/');
        }

        private static string GetUniqueCleanFileName(string fileName, string suffix = "", DateTime? utcNow = null)
        {
            if (utcNow == null) utcNow = DateTime.UtcNow;
            var ext = Path.GetExtension(fileName);
            fileName = CleanFileName(Path.GetFileNameWithoutExtension(fileName));
            return $"{fileName}-{utcNow.Value.Ticks}{suffix}{ext}";
        }

        private static string CleanFileName(string filename)
        {
            var invalidChars = System.IO.Path.GetInvalidFileNameChars();
            return string.Join("-", filename.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries))
                .Replace(' ', '-')
                .ToLowerInvariant()
                .TrimEnd('.');
        }

        private static string GetTodayDirectory(int? tenantId) =>
            $"files/{tenantId ?? 0}/{DateTime.UtcNow:yyyy/MM/dd}";

        private static bool IsValidFile(IFormFile file)
        {
            return file.Length > 0;
        }

        private static bool IsValidImage(IFormFile file)
        {
            return IsValidFile(file) && file.ContentType.ToLowerInvariant().StartsWith("image/");
        }
    }
}
