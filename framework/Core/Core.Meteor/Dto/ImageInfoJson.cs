using System.Text.Json;

namespace Core.Meteor.Dto
{
    public class ImageInfoJson
    {
        public string? FileName { get; set; }
        public string? Alt { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
