using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.ModelPropertyElement.Dto
{
    public class UpdateModelPropertyElementInDto : SaanaaDbUpdateInDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Attributes { get; set; }

    }
}
