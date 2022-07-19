using Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Queries
{
    public class GetTenantUrlAsDropDown : DbQueryAsDropDown<TenantUrl>
    {
        public GetTenantUrlAsDropDown() : base("[Identity].[TenantUrl]")
        {
        }
    }
}
