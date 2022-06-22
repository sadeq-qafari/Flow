using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Queries
{
    public class GetTenantUrlByIds : SaanaaDbQueryByIds<TenantUrl>
    {
        public GetTenantUrlByIds() : base("[Identity].[TenantUrl]")
        {
        }
    }
}