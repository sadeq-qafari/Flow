using Core.Meteor;

namespace Tenant.Operations.OrganizationDetail.Queries
{
    public class GetOrganizationDetailByIds : DbQueryByIds<OrganizationDetail>
    {
        public GetOrganizationDetailByIds() : base("[Tenant].[OrganizationDetail]")
        {
        }
    }
}