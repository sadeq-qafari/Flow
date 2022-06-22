using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.FormAction.Dtos
{
    public class FormActionUpdateInDto : SaanaaDbUpdateInDto
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? ColorHex { get; set; }
        public int FormId { get; set; }
        public int TypeLookup { get; set; }
        public string? Script { get; set; }

    }
}
