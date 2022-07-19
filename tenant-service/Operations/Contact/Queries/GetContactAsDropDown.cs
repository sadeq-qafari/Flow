using Core.Meteor;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContactAsDropDown : DbQueryAsDropDown<Contact>
    {
        public GetContactAsDropDown() : base("[Tenant].[Contact]")
        {
        }
    }
}
