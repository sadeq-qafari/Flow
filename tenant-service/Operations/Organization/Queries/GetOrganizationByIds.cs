using Saanaa.Core.Meteor;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganizationByIds : SaanaaDbQueryByIds<Organization>
    {
        public GetOrganizationByIds() : base("[Tenant].[Organization]")
        {
        }
    }
}