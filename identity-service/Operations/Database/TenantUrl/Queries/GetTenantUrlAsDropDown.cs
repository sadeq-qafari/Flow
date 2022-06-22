using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Queries
{
    public class GetTenantUrlAsDropDown : SaanaaDbQueryAsDropDown<TenantUrl>
    {
        public GetTenantUrlAsDropDown() : base("[Identity].[TenantUrl]")
        {
        }
    }
}
