using Saanaa.Core.Meteor;

namespace Tenant.Operations.Role.Queries
{
    public class GetRoleAsDropDown : SaanaaDbQueryAsDropDown<Role>
    {
        public GetRoleAsDropDown() : base("[Tenant].[Role]")
        {
        }
    }
}
