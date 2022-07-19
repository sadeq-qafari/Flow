using Core.Meteor.Dto;

namespace Core.Operations.ModelPropertyLookup.Dto
{
    public class UpdateModelPropertyLookupInDto : DbUpdateInDto
    {
        public int ModelPropertyId { get; set; }
        public string? ModelPropertyTitle { get; set; }
        public string Title { get; set; }
        public int Value { get; set; }

    }
}
