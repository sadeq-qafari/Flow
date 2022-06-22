using Identity.Operations.Database.UserPermission.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.UserPermission.Queries
{
    public class GetUserPermissionPage : SaanaaDbQueryPage<UserPermissionDto>
    {
        public GetUserPermissionPage() : base("[Identity].[UserPermission]")
        {
        }



        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {

            return SqlFactory!.Create().Select("[Identity].[UserPermission] UserPermission", isForCount ? "COUNT(*)" : @"
						UserPermission.*, 
						[User].Title AS UserTitle,
						Permission.Name AS PermissionName,
						Branch.Title AS BranchTitle")
                .LeftJoin("[Identity].[User]",  "UserPermission.UserId = [User].Id  AND  [User].IsDeleted=0")
                .LeftJoin("[Identity].[Permission] Permission",  "UserPermission.PermissionId = Permission.Id  AND  Permission.IsDeleted=0")
                .LeftJoin("[Identity].[Branch] Branch",  "UserPermission.BranchId = Branch.Id  AND  Branch.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[UserPermission].[{fieldName}]";
    }
}
