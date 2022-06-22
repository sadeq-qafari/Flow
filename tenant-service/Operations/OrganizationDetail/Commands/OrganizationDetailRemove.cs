using Saanaa.Core.Meteor;

namespace Tenant.Operations.OrganizationDetail.Commands
{
    public class OrganizationDetailRemove : SaanaaDbDeleteAsync
    {
        public OrganizationDetailRemove() : base("[Tenant].[OrganizationDetail]")
        {
        }
    }
}