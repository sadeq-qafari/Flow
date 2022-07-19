using Core.Meteor;
using Tenant.Operations.Contact.Dto;

namespace Tenant.Operations.Contact.Commands
{
    public class UpdateContact : DbUpdateAsync<UpdateContactInDto>
    {
        public UpdateContact() : base("[Tenant].[Contact]",
            "[Title]=@Title, [Value]=@Value")
        {
        }
    }
}
