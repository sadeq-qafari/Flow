using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.AspNetCore.Operations.Db.Identity.Dto;
using Core.AspNetCore.Redis;
using Meteor.Operation;
using Meteor.Utils;

namespace Core.AspNetCore.Operations.Db.Identity.Commands
{
    public class CheckPermission : OperationAsync<CheckPermissionInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            var redis = OperationFactory!.GetService<RedisCache>()
                        ?? throw Errors.InternalError("redis_service_not_registered");
            var permissionRedisKey = RedisCache.Keys.UserPermissionList(Input.TenantId, Input.BranchId, Input.UserId);
            var res = (await redis.Db.SetMembersAsync(permissionRedisKey)).First();
            if (string.IsNullOrEmpty(res)) res = "{}";
            var permissionStore = JsonSerializer.Deserialize<PermissionStore?>(res);
            Output = permissionStore?.HasPermission(Input.PermissionName) == true;
        }
    }
}
