using Saanaa.Core.Meteor;
using Tenant.Operations.Contact.Dto;

namespace Tenant.Operations.Contact.Commands
{
    public class UpdateContact : SaanaaDbUpdateAsync<UpdateContactInDto>
    {
        public UpdateContact() : base("[Tenant].[Contact]",
            "[Title]=@Title, [Value]=@Value")
        {
        }
    }
}
