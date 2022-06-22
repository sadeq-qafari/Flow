using Saanaa.Core.Meteor;

namespace Tenant.Operations.OrganizationDetail.Queries
{
    public class GetOrganizationDetailExcel : SaanaaDbQueryExcel<OrganizationDetail>
    {
        public GetOrganizationDetailExcel() : base("[Tenant].[OrganizationDetail]")
        {
        }
    }
}