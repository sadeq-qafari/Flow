using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantByIds : SaanaaDbQueryByIds<Tenant>
    {
        public GetTenantByIds() : base("[Identity].[Tenant]")
        {
        }
    }
}
