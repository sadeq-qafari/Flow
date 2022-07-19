using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Logic.Dto;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.UserRole.Queries
{
    public class GetUserRoleIds : DbOperationAsync<UserBranchDto, IEnumerable<int>>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql
                    .Select("[Identity].[UserRole]", "RoleId")
                    .Where("TenantId=@TenantId AND BranchId=@BranchId AND UserId=@UserId"))
                .QueryAsync<int>();
        }
    }
}
