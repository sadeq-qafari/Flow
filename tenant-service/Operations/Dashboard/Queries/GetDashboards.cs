using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Meteor.Operation.Db;
using Meteor.Utils;
using Core.AspNetCore.Operations.Db.Identity.Dto;
using Core.AspNetCore.Redis;
using Tenant.Operations.Dashboard.Dtos;
using Tenant.Operations.Report.Dtos;
using Tenant.Operations.Report.Queries;

namespace Tenant.Operations.Dashboard.Queries
{
    public class GetDashboards : DbOperationAsync<GetDashboardsInDto, List<DashboardDto>>
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
            var reports =
                await NewSql(@"EXECUTE Tenant.sp_Reports @ActionBy = @ActionBy, @TenantId = @TenantId")
                    .QueryAsync<ReportDto>();

            var userPermissions =
                (await _redisCache.Db.SetMembersAsync(RedisCache.Keys.UserPermissionList(Input.TenantId,
                    Input.BranchId ?? Input.TenantId, Input.ActionBy)))
                .Select(x => (string) x)
                .FirstOrDefault();
            var userPermissionStore = new PermissionStore(userPermissions!);

            reports = reports.Where(x => x.PermissionName == null
                                         || userPermissionStore?.HasPermission(x.PermissionName) == true)
                .ToList();

            foreach (var item in reports)
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Tenant_Id", Input.TenantId);
                foreach (var param in GetParameters(item.Parameters, item.DashboardReportParameters))
                    dynamicParameters.Add(param.Key, param.Value);
                try
                {
                    item.Result = await OperationFactory!.New<GetReportResult>().ExecuteAsync(new ReportResultInDto()
                    {
                        Params = dynamicParameters,
                        Query = item.Query
                    });
                }
                catch (Exception e)
                {
                    item.Result = new List<object>();
                }

            }

            Output = reports.GroupBy(x => x.DashboardId).Select(x => new DashboardDto
            {
                Id = x.Key,
                Title = x.First(p => p.DashboardId == x.Key).DashboardTitle,
                Index = x.First(p => p.DashboardId == x.Key).DashboardIndex,
                Reports = x.Select(p => new ReportDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Name = p.Name,
                    Icon = p.Icon,
                    TypeLookup = p.TypeLookup,
                    Link = p.Link,
                    Size = p.Size,
                    Parameters = p.Parameters,
                    Result = p.Result,
                }).ToList()
            }).ToList();
        }

        public Dictionary<string, object> GetParameters(Dictionary<string, object>? Parameters,
            Dictionary<string, object>? DashboardReportParameters)
        {
            var res = new Dictionary<string, object>();
            if (Parameters != null && Parameters.Count > 0)
            {
                foreach (var param in Parameters)
                {
                    if (DashboardReportParameters?.Any(x => x.Key == param.Key) == true)
                    {
                        var param1 = DashboardReportParameters.First(x => x.Key == param.Key);
                        res.Add(param1.Key, param1.Value);
                    }
                    else
                    {
                        res.Add(param.Key, param.Value);
                    }
                }
            }
            return res;
        }
    }
}
