using Saanaa.Core.Meteor;

namespace Tenant.Operations.Role.Queries
{
    public class GetRole : SaanaaDbSelectAsync<Role?>
    {
        public GetRole() : base("[Tenant].[Role]")
        {
        }
    }
}