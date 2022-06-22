using Identity.Operations.Database.UserRole.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserRole.Queries
{
    public class GetUserRolePage : SaanaaDbQueryPage<UserRoleDto>
    {
        public GetUserRolePage() : base("[Identity].[UserRole]")
        {
        }



        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {

            return SqlFactory!.Create().Select("[Identity].[UserRole] UserRole", isForCount ? "COUNT(*)" : @"
						UserRole.*, 
						[User].Title AS UserTitle,
						Role.Title AS RoleTitle,
						Branch.Title AS BranchTitle")
                .LeftJoin("[Identity].[User]",  "UserRole.UserId = [User].Id  AND  [User].IsDeleted=0")
                .LeftJoin("[Identity].[Role] Role",  "UserRole.RoleId = Role.Id  AND  Role.IsDeleted=0")
                .LeftJoin("[Identity].[Branch] Branch",  "UserRole.BranchId = Branch.Id  AND  Branch.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[UserRole].[{fieldName}]";
    }
}
