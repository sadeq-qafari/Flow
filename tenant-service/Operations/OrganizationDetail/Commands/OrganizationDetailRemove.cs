using Core.Meteor;

namespace Tenant.Operations.OrganizationDetail.Commands
{
    public class OrganizationDetailRemove : DbDeleteAsync
    {
        public OrganizationDetailRemove() : base("[Tenant].[OrganizationDetail]")
        {
        }
    }
}