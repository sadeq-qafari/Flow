using Saanaa.Core.Meteor;
using Tenant.Operations.Contact.Dto;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContactPage : SaanaaDbQueryPage<ContactDto>
    {
        public GetContactPage() : base("[Tenant].[Contact]")
        {
        }
        
    }
}