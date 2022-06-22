using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Queries
{
    public class GetTenantUserExcel : SaanaaDbQueryExcel<TenantUser>
    {
        public GetTenantUserExcel() : base("[Identity].[TenantUser]")
        {
        }
    }
}
