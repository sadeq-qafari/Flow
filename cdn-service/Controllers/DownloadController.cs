using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Cdn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DownloadController : ControllerBase
    {
        private static readonly FileExtensionContentTypeProvider FileExtensionContentTypeProvider = new FileExtensionContentTypeProvider();

        [HttpGet("{**path}")]
        public IActionResult UploadFiles(string path)
        {
            var fileName = Path.GetFullPath(Path.Combine("files", path));
            if (!System.IO.File.Exists(fileName))
                return NotFound();

            FileExtensionContentTypeProvider.TryGetContentType(fileName, out var contentType);
            return PhysicalFile(fileName, contentType);
        }
    }
}
