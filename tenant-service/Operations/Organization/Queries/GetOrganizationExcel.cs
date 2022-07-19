using Core.Meteor;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganizationExcel : DbQueryExcel<Organization>
    {
        public GetOrganizationExcel() : base("[Tenant].[Organization]")
        {
        }
    }
}