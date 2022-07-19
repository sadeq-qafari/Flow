using Core.Meteor;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantExcel : DbQueryExcel<Tenant>
    {
        public GetTenantExcel() : base("[Identity].[Tenant]")
        {
        }
    }
}
