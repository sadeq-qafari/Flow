using Core.Meteor;

namespace Tenant.Operations.Person.Queries
{
    public class GetPerson : DbSelectAsync<Person?>
    {
        public GetPerson() : base("[Tenant].[Person]")
        {
        }
    }
}