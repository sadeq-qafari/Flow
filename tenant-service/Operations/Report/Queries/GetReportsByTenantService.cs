using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Meteor.Utils;
using Saanaa.Core.AspNetCore.Operations.Db.Identity.Dto;
using Saanaa.Core.AspNetCore.Redis;
using Tenant.Operations.Dashboard.Dtos;

namespace Tenant.Operations.Report.Queries
{
    public class GetReportsByTenantService : DbOperationAsync<GetDashboardsInDto, IEnumerable<Report>>
    {
        private RedisCache _redisCache;

        protected override Task PrepareExecutionAsync()
        {
            _redisCache = OperationFactory!.GetService<RedisCache>()
                          ?? throw Errors.NotFound("redis_cache_service");
            return Task.CompletedTask;
        }

        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.Select("[Tenant].[Report]","Report.*")
                .InnerJoin("[Core].[Service]", "ServiceName = Service.Name")
                .InnerJoin("[Identity].[TenantService]", "ServiceId = Service.Id AND TenantService.TenantId = @TenantId")
            ).QueryAsync<Report>();

            var userPermissions =
                (await _redisCache.Db.SetMembersAsync(RedisCache.Keys.UserPermissionList(Input.TenantId,
                    Input.BranchId ?? Input.TenantId, Input.ActionBy)))
                .Select(x => (string) x)
                .FirstOrDefault();
            var userPermissionStore = new PermissionStore(userPermissions!);

            Output = Output.Where(x => x.PermissionName == null
                                       || userPermissionStore?.HasPermission(x.PermissionName) == true)
                .ToList();
        }
    }
}
