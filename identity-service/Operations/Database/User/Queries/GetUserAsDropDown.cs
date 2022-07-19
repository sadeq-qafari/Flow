using Identity.Operations.Database.User.Dtos;
using Meteor.Database.SqlDialect;
using Core.Meteor;

namespace Identity.Operations.Database.User.Queries
{
    public class GetUserAsDropDown : DbQueryAsDropDown<UserDto>
    {
        public GetUserAsDropDown() : base("[Identity].[User]","Title","Id","RoleTitle")
        {
        }

        protected override ISqlDialect GetSelectSql(ISqlDialect sql)
        {
            return SqlFactory!.Create().Select("[Identity].[User]", "DISTINCT [User].Id, [User].Title, Role.Title AS RoleTitle")
                .InnerJoin("[Identity].[TenantUser] TenantUser",
                    "TenantUser.UserId = [User].Id  AND  TenantUser.TenantId=@TenantId  AND  TenantUser.IsDeleted=0")
                .LeftJoin("[Identity].[UserRole] UserRole",
                    @"UserRole.UserId = [User].Id 
                              AND UserRole.IsDeleted = 0 
                              AND UserRole.IsDefault = 1 
                              AND UserRole.TenantId = @TenantId")
                .LeftJoin("[Identity].[Role] Role",
                    "Role.Id = UserRole.RoleId AND Role.IsDeleted = 0");
        }

        protected override SqlWhereBuilder GetWhereSql(SqlWhereBuilder whereBuilder)
        {
            return whereBuilder.Where($"{GetFieldName("IsDeleted")}=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return $"[User].{fieldName}";
        }
    }
}
