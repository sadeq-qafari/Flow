using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.Lookup.Dtos
{
    public class LookupAddInDto : SaanaaDbInsertInDto
    {
        public string Title { get; set; }
        public int TypeLookup { get; set; }
        public string? Query { get; set; }
        public int? WebServiceId { get; set; }
        public string? Description { get; set; }

    }
}
