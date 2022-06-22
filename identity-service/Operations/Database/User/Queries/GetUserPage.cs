using System.Collections.Generic;
using System.Linq;
using Identity.Operations.Database.User.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Database.User.Queries
{
    public class GetUserPage : SaanaaDbQueryPage<UserDto>
    {
        public GetUserPage() : base("[Identity].[User]")
        {
        }

        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Identity].[User]", "[User].*, Tenant.Title AS TenantTitle")
                .InnerJoin("[Identity].[TenantUser] TenantUser", "[User].Id = TenantUser.UserId AND TenantUser.IsDeleted = 0")
                .InnerJoin("[Identity].[Tenant] Tenant", "TenantUser.TenantId = Tenant.Id AND Tenant.IsDeleted = 0");
        }

        protected override void BuildWhere(SqlWhereBuilder builder, List<FilterItem> filterItems)
        {
            builder.Where(
                Input.HasTenant0
                    ? $"{GetFieldName("IsDeleted")}=0"
                    : $"{GetFieldName("IsDeleted")}=0 AND (TenantUser.TenantId=@Tenant_Id)");

            if (!filterItems.Any())
                return;
            foreach (var filterItem in filterItems.Where(x => x.IsValid()))
                builder.And(filterItem.GetWhereSql(GetFieldName(filterItem.FieldName)));
        }

        protected override string GetFieldName(string fieldName) =>
            fieldName switch
            {
                "TenantTitle" => "Tenant.Title",
                _ => $"[User].{fieldName}"
            };
    }
}
