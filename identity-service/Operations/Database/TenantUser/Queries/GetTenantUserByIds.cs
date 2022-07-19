using Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Queries
{
    public class GetTenantUserByIds : DbQueryByIds<TenantUser>
    {
        public GetTenantUserByIds() : base("[Identity].[TenantUser]")
        {
        }
    }
}
