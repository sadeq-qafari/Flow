using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantAsDropDown : SaanaaDbQueryAsDropDown<Tenant>
    {
        public GetTenantAsDropDown() : base("[Identity].[Tenant]")
        {
        }

        protected override SqlWhereBuilder GetWhereSql(SqlWhereBuilder whereBuilder) =>
            whereBuilder.Where(
                $"[Tenant].IsDeleted=0 {(Input.TenantId != 1 ? "AND [Tenant].TenantId=@TenantId" : "")}");
    }
}
