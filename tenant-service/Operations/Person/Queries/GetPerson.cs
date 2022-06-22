using Saanaa.Core.Meteor;

namespace Tenant.Operations.Person.Queries
{
    public class GetPerson : SaanaaDbSelectAsync<Person?>
    {
        public GetPerson() : base("[Tenant].[Person]")
        {
        }
    }
}