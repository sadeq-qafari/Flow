using Saanaa.Core.Meteor;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContact : SaanaaDbSelectAsync<Contact?>
    {
        public GetContact() : base("[Tenant].[Contact]")
        {
        }
    }
}