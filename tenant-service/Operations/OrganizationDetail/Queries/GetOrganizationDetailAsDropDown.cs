using Core.Meteor;

namespace Tenant.Operations.OrganizationDetail.Queries
{
    public class GetOrganizationDetailAsDropDown : DbQueryAsDropDown<OrganizationDetail>
    {
        public GetOrganizationDetailAsDropDown() : base("[Tenant].[OrganizationDetail]")
        {
        }
    }
}
