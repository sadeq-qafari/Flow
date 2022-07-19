using Core.Meteor;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContactExcel : DbQueryExcel<Contact>
    {
        public GetContactExcel() : base("[Tenant].[Contact]")
        {
        }
    }
}