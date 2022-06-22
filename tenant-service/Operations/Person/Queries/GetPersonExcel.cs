using Saanaa.Core.Meteor;

namespace Tenant.Operations.Person.Queries
{
    public class GetPersonExcel : SaanaaDbQueryExcel<Person>
    {
        public GetPersonExcel() : base("[Tenant].[Person]")
        {
        }
    }
}