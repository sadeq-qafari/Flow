using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.ModelPropertyElement.Dto
{
    public class AddModelPropertyElementInDto : SaanaaDbInsertInDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Attributes { get; set; }

    }
}
