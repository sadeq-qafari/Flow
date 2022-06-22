using Saanaa.Core.Meteor;

namespace Tenant.Operations.Role.Queries
{
    public class GetRoleByIds : SaanaaDbQueryByIds<Role>
    {
        public GetRoleByIds() : base("[Tenant].[Role]")
        {
        }
    }
}