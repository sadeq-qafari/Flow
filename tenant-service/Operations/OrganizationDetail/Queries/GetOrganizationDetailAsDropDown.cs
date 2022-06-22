using Saanaa.Core.Meteor;

namespace Tenant.Operations.OrganizationDetail.Queries
{
    public class GetOrganizationDetailAsDropDown : SaanaaDbQueryAsDropDown<OrganizationDetail>
    {
        public GetOrganizationDetailAsDropDown() : base("[Tenant].[OrganizationDetail]")
        {
        }
    }
}
