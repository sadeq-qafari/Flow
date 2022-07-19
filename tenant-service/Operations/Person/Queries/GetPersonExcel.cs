using Core.Meteor;

namespace Tenant.Operations.Person.Queries
{
    public class GetPersonExcel : DbQueryExcel<Person>
    {
        public GetPersonExcel() : base("[Tenant].[Person]")
        {
        }
    }
}