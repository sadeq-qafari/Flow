using Core.Meteor.Dto;

namespace Flow.Operations.Element.Dtos
{
    public class ElementAddInDto : DbInsertInDto
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Config { get; set; }
        public string? AcceptableTypes { get; set; }
        public string? ComponentName { get; set; }

    }
}
