using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantExcel : SaanaaDbQueryExcel<Tenant>
    {
        public GetTenantExcel() : base("[Identity].[Tenant]")
        {
        }
    }
}
