using System.Collections.Generic;

namespace Cdn.Models
{
    public class ImageUploadResult
    {
        public string FileName { get; set; }
        public List<string> Urls { get; set; }
    }
}
