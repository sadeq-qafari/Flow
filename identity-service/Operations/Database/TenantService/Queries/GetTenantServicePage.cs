using Identity.Operations.Database.TenantService.Dtos;
using Meteor.Database.SqlDialect;
using Core.Meteor;

namespace Identity.Operations.Database.TenantService.Queries
{
    public class GetTenantServicePage : DbQueryPage<TenantServiceDto>
    {
        public GetTenantServicePage() : base("[Identity].[TenantService]")
        {
        }

        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Identity].[TenantService] TenantService", isForCount ? "COUNT(*)" : @"
						TenantService.*, 
						Service.Title AS ServiceTitle,
                        Tenant.Title AS TenantTitle")
                .LeftJoin("[Core].[Service] Service",  "TenantService.ServiceId = Service.Id  AND  Service.IsDeleted=0")
                .LeftJoin("[Identity].[Tenant] Tenant",  "TenantService.TenantId = Tenant.Id  AND  Tenant.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[TenantService].[{fieldName}]";
    }
}
