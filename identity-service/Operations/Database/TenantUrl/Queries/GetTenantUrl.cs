using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Queries
{
    public class GetTenantUrl : SaanaaDbSelectAsync<TenantUrl?>
    {
        public GetTenantUrl() : base("[Identity].[TenantUrl]")
        {
        }
    }
}