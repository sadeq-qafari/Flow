using Core.Meteor.Dto;

namespace Flow.Operations.LookupItem.Dtos
{
    public class LookupItemAddInDto : DbInsertInDto
    {
        public int LookupId { get; set; }
        public string Title { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public int Index { get; set; }
        public string? Icon { get; set; }
        public string? ColorHex { get; set; }

    }
}
