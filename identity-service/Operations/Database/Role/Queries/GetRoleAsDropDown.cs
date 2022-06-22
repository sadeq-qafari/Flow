using Identity.Operations.Database.Role.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Role.Queries
{
    public class GetRoleAsDropDown : SaanaaDbQueryAsDropDown<RoleDto>
    {
        public GetRoleAsDropDown() : base("[Identity].[Role]","Title","Id","ServiceTitle")
        {
        }

        protected override ISqlDialect GetSelectSql(ISqlDialect sql)
        {
            return SqlFactory!.Create().Select("[Identity].[Role] Role","DISTINCT Role.Id,Role.Title,Service.Title ServiceTitle")
                .LeftJoin("[Core].[Service] Service", "Role.ServiceId = Service.Id  AND  Service.IsDeleted=0")
                .InnerJoin("[Identity].[TenantService] TenantService",
                    @"(TenantService.ServiceId = Service.Id
                               AND TenantService.TenantId=@TenantId)
                               OR Role.ServiceId IS NULL");
        }

        protected override SqlWhereBuilder GetWhereSql(SqlWhereBuilder whereBuilder)
        {
            return whereBuilder.Where($"{GetFieldName("IsDeleted")}=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return $"Role.{fieldName}";
        }
    }
}
