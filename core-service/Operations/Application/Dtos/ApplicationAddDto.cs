using Core.Meteor.Dto;

namespace Core.Operations.Application.Dtos
{
    public class ApplicationAddInDto : DbInsertInDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Terms { get; set; }
        public int? GatewayDetailId { get; set; }
    }
}
