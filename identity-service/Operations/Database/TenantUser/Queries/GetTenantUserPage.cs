using Identity.Operations.Database.TenantUser.Dtos;
using Meteor.Database.SqlDialect;
using Core.Meteor;

namespace Identity.Operations.Database.TenantUser.Queries
{
    public class GetTenantUserPage : DbQueryPage<TenantUserDto>
    {
        public GetTenantUserPage() : base("[Identity].[TenantUser]")
        {
        }



        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {

            return SqlFactory!.Create().Select("[Identity].[TenantUser] TenantUser", isForCount ? "COUNT(*)" : @"
						TenantUser.*, 
						Branch.Title AS BranchTitle,
						[User].Title AS UserTitle")
                .LeftJoin("[Identity].[Branch] Branch",  "TenantUser.BranchId = Branch.Id  AND  Branch.IsDeleted=0")
                .LeftJoin("[Identity].[User]",  "TenantUser.UserId = [User].Id  AND  [User].IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[TenantUser].[{fieldName}]";
    }
}
