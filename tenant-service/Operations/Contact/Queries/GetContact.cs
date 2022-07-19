using Core.Meteor;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContact : DbSelectAsync<Contact?>
    {
        public GetContact() : base("[Tenant].[Contact]")
        {
        }
    }
}