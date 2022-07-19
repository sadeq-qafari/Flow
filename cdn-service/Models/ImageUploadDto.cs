namespace Cdn.Models
{
    public class ImageUploadInDto
    {
        public string? Sizes { get; set; }
    }

    public class ImageSizeDto
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Suffix { get; set; }
    }
}
