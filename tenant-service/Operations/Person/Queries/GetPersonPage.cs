using Core.Meteor;
using Tenant.Operations.Person.Dto;

namespace Tenant.Operations.Person.Queries
{
    public class GetPersonPage : DbQueryPage<PersonDto>
    {
        public GetPersonPage() : base("[Tenant].[Person]")
        {
        }
        
    }
}