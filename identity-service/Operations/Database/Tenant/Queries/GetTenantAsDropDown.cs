using Meteor.Database.SqlDialect;
using Core.Meteor;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantAsDropDown : DbQueryAsDropDown<Tenant>
    {
        public GetTenantAsDropDown() : base("[Identity].[Tenant]")
        {
        }

        protected override SqlWhereBuilder GetWhereSql(SqlWhereBuilder whereBuilder) =>
            whereBuilder.Where(
                $"[Tenant].IsDeleted=0 {(Input.TenantId != 1 ? "AND [Tenant].TenantId=@TenantId" : "")}");
    }
}
