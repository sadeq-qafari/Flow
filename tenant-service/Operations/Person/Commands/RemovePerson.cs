using Saanaa.Core.Meteor;

namespace Tenant.Operations.Person.Commands
{
    public class RemovePerson : SaanaaDbDeleteAsync
    {
        public RemovePerson() : base("[Tenant].[Person]")
        {
        }
    }
}