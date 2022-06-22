using Saanaa.Core.Meteor;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganizationExcel : SaanaaDbQueryExcel<Organization>
    {
        public GetOrganizationExcel() : base("[Tenant].[Organization]")
        {
        }
    }
}