using Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Queries
{
    public class GetTenantUrl : DbSelectAsync<TenantUrl?>
    {
        public GetTenantUrl() : base("[Identity].[TenantUrl]")
        {
        }
    }
}