using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Queries
{
    public class GetTenantUserAsDropDown : SaanaaDbQueryAsDropDown<TenantUser>
    {
        public GetTenantUserAsDropDown() : base("[Identity].[TenantUser]")
        {
        }
    }
}
