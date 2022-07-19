using Core.Meteor.Dto;

namespace Tenant.Operations.Contact.Dto
{
    public class AddContactInDto : DbInsertInDto
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public int ModelId { get; set; }
        public int EntityId { get; set; }
    }
}
