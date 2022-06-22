using Saanaa.Core.Meteor;

namespace Tenant.Operations.OrganizationDetail.Queries
{
    public class GetOrganizationDetailByIds : SaanaaDbQueryByIds<OrganizationDetail>
    {
        public GetOrganizationDetailByIds() : base("[Tenant].[OrganizationDetail]")
        {
        }
    }
}