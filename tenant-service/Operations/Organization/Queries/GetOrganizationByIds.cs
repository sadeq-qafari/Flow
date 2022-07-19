using Core.Meteor;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganizationByIds : DbQueryByIds<Organization>
    {
        public GetOrganizationByIds() : base("[Tenant].[Organization]")
        {
        }
    }
}