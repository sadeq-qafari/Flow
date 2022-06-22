using Saanaa.Core.Meteor;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContactByIds : SaanaaDbQueryByIds<Contact>
    {
        public GetContactByIds() : base("[Tenant].[Contact]")
        {
        }
    }
}