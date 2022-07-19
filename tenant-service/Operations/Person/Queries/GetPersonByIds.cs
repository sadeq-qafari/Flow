using Core.Meteor;

namespace Tenant.Operations.Person.Queries
{
    public class GetPersonByIds : DbQueryByIds<Person>
    {
        public GetPersonByIds() : base("[Tenant].[Person]")
        {
        }
    }
}