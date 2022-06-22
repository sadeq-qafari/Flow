using Saanaa.Core.Meteor;

namespace Tenant.Operations.Person.Queries
{
    public class GetPersonByIds : SaanaaDbQueryByIds<Person>
    {
        public GetPersonByIds() : base("[Tenant].[Person]")
        {
        }
    }
}