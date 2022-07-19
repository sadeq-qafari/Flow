using Core.Meteor;

namespace Tenant.Operations.OrganizationDetail.Queries
{
    public class GetOrganizationDetailExcel : DbQueryExcel<OrganizationDetail>
    {
        public GetOrganizationDetailExcel() : base("[Tenant].[OrganizationDetail]")
        {
        }
    }
}