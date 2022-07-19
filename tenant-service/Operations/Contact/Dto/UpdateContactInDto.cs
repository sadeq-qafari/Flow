using Core.Meteor.Dto;

namespace Tenant.Operations.Contact.Dto
{
    public class UpdateContactInDto : DbUpdateInDto
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public int ModelId { get; set; }
        public int EntityId { get; set; }
    }
}
