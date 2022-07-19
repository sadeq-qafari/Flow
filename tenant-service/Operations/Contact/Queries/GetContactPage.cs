using Core.Meteor;
using Tenant.Operations.Contact.Dto;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContactPage : DbQueryPage<ContactDto>
    {
        public GetContactPage() : base("[Tenant].[Contact]")
        {
        }
        
    }
}