using Core.Meteor.Dto;

namespace Core.Operations.ModelFilter.Dtos
{
    public class ModelFilterUpdateInDto : DbUpdateInDto
    {
        public string Title { get; set; }
        public int? ModelId { get; set; }
        public string FilterString { get; set; }
        public int TypeLookup { get; set; }

    }
}
