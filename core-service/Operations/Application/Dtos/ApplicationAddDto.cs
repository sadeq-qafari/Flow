using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.Application.Dtos
{
    public class ApplicationAddInDto : SaanaaDbInsertInDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Terms { get; set; }
        public int? GatewayDetailId { get; set; }
    }
}
