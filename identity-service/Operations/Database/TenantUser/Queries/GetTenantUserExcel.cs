using Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Queries
{
    public class GetTenantUserExcel : DbQueryExcel<TenantUser>
    {
        public GetTenantUserExcel() : base("[Identity].[TenantUser]")
        {
        }
    }
}
