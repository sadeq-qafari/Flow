using Core.Meteor;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContactByIds : DbQueryByIds<Contact>
    {
        public GetContactByIds() : base("[Tenant].[Contact]")
        {
        }
    }
}