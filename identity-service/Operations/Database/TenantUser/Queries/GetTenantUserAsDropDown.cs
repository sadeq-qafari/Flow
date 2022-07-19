using Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Queries
{
    public class GetTenantUserAsDropDown : DbQueryAsDropDown<TenantUser>
    {
        public GetTenantUserAsDropDown() : base("[Identity].[TenantUser]")
        {
        }
    }
}
