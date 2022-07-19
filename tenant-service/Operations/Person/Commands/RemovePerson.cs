using Core.Meteor;

namespace Tenant.Operations.Person.Commands
{
    public class RemovePerson : DbDeleteAsync
    {
        public RemovePerson() : base("[Tenant].[Person]")
        {
        }
    }
}