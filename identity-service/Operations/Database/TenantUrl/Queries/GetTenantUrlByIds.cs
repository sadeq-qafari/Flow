using Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Queries
{
    public class GetTenantUrlByIds : DbQueryByIds<TenantUrl>
    {
        public GetTenantUrlByIds() : base("[Identity].[TenantUrl]")
        {
        }
    }
}