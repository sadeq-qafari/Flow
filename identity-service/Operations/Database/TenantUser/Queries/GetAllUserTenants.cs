using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantUrl.Queries;
using Identity.Operations.Database.TenantUser.Dtos;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.TenantUser.Queries
{
    public class GetAllUserTenants : DbOperationAsync<string, IEnumerable<UserTenantDto>>
    {
        protected override async Task ExecutionAsync()
        {
            const string sqlText = @"
SELECT DISTINCT [Identity].Tenant.Id
     ,ISNULL(Organization.Title,[Identity].Tenant.Title) AS Title
     ,TenantUser.BranchId
     ,Branch.Title AS BranchTitle
     ,TenantUser.UserId
     ,TenantUser.IsDefault
     ,COUNT(RoleId) RoleCount
     ,Organization.Logo
  FROM  [Identity].TenantUser TenantUser
  LEFT JOIN [Identity].UserRole ON TenantUser.TenantId = [Identity].UserRole.TenantId AND TenantUser.UserId = UserRole.UserId AND [Identity].UserRole.IsDeleted = 0
  INNER JOIN [Identity].Tenant ON TenantUser.TenantId = Tenant.Id AND Tenant.IsDeleted = 0 AND [Identity].Tenant.IsActive = 1
  INNER JOIN [Identity].Branch ON TenantUser.BranchId = Branch.Id AND [Identity].Branch.IsDeleted = 0 AND [Identity].Branch.IsActive = 1
  INNER JOIN [Identity].[User] ON [Identity].[User].Id = TenantUser.UserId
  LEFT JOIN [Tenant].Organization ON Organization.Id = TenantUser.TenantId AND Organization.IsDeleted = 0 
WHERE [Identity].[User].NormalizedUserName = LOWER(@Username) AND TenantUser.IsBanned = 0 AND TenantUser.IsDeleted = 0
GROUP BY [Identity].Tenant.Id
        ,[Identity].Tenant.Title
        ,TenantUser.BranchId
        ,Branch.Title
        ,TenantUser.UserId
        ,TenantUser.IsDefault
        ,Organization.Logo
        ,Organization.Title
";
            Output = await NewSql(sqlText, new {Username = Input}).QueryAsync<UserTenantDto>();
            foreach (var userTenant in Output)
                userTenant.BaseUrls = await OperationFactory!.New<GetTenantUrls>().ExecuteAsync(userTenant.Id);
        }
    }
}
