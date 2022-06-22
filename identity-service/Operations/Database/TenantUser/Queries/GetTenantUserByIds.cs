using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Queries
{
    public class GetTenantUserByIds : SaanaaDbQueryByIds<TenantUser>
    {
        public GetTenantUserByIds() : base("[Identity].[TenantUser]")
        {
        }
    }
}
