using System.Threading.Tasks;
using Identity.Operations.Database.TenantUrl.Queries;
using Identity.Operations.Database.TenantUser.Dtos;
using Identity.Operations.Logic.Dto;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.TenantUser.Queries
{
    public class GetUserTenant : DbOperationAsync<UserBranchDto, UserTenantDto>
    {
        protected override async Task ExecutionAsync()
        {
            const string sqlText = @"
SELECT t.Id, t.Title, tu.IsDefault, tu.BranchId, b.Title AS BranchTitle 
FROM [Identity].[TenantUser] tu
    INNER JOIN [Identity].[Tenant] t ON tu.TenantId = t.Id
    INNER JOIN [Identity].Branch b ON tu.BranchId = b.Id
WHERE tu.TenantId=@TenantId AND tu.BranchId=@BranchId AND tu.UserId=@UserId
";
            Output = await NewSql(sqlText).QueryFirstOrDefaultAsync<UserTenantDto?>();
            if (Output != null) Output.BaseUrls = await OperationFactory!.New<GetTenantUrls>().ExecuteAsync(Output.Id);
        }
    }
}
