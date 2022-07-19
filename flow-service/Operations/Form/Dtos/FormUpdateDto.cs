using Core.Meteor.Dto;

namespace Flow.Operations.Form.Dtos
{
    public class FormUpdateInDto : DbUpdateInDto
    {
        public string? Name { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Layout { get; set; }
        public bool? IsAddable { get; set; }
        public bool? IsUpdatable { get; set; }
        public bool? IsDeletable { get; set; }

    }
}
