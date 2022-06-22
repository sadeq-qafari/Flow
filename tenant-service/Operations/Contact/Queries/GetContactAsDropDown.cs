using Saanaa.Core.Meteor;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContactAsDropDown : SaanaaDbQueryAsDropDown<Contact>
    {
        public GetContactAsDropDown() : base("[Tenant].[Contact]")
        {
        }
    }
}
