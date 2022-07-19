using Core.Meteor;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantByIds : DbQueryByIds<Tenant>
    {
        public GetTenantByIds() : base("[Identity].[Tenant]")
        {
        }
    }
}
