using Core.Meteor.Dto;

namespace Core.Operations.ModelFilter.Dtos
{
    public class ModelFilterAddInDto : DbInsertInDto
    {
        public string Title { get; set; }
        public int? ModelId { get; set; }
        public string FilterString { get; set; }
        public int TypeLookup { get; set; }

    }
}
