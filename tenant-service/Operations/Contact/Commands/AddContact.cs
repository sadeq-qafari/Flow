using Core.Meteor;
using Tenant.Operations.Contact.Dto;

namespace Tenant.Operations.Contact.Commands
{
    public class AddContact : DbInsertAsync<AddContactInDto>
    {
        public AddContact() : base("[Tenant].[Contact]",
            "[Title], [Value], [ModelId], [EntityId]",
            "@Title, @Value, @ModelId, @EntityId")
        {
        }
    }
}

