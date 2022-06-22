using System.Threading.Tasks;
using Identity.Operations.Database.User.Queries;
using Meteor.Operation.Db;
using Meteor.Utils;
using Saanaa.Core.AspNetCore.Redis;
using Saanaa.Core.Meteor.Dto;

namespace Identity.Operations.Logic
{
    public class ClearUserCache : DbOperationAsync<SaanaaDbUpdateInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            var user = await New<GetUser>().ExecuteAsync(Input.ModifiedBy.GetValueOrDefault(0));
            if (user == null)
                throw Errors.InvalidInput("user_id");

            var redis = OperationFactory?.GetService<RedisCache>()
                        ?? throw Errors.InvalidOperation("redis_is_not_registered");

            var keys = new[]
            {
                $"user:register:{user.UserName}",
                $"user:verify-code:{user.UserName}"
                //, RedisCache.Keys.UserPermissionList(Input.TenantId, Input.ModifiedBy.GetValueOrDefault(0))
            };

            foreach (var key in keys)
                await redis.Db.KeyDeleteAsync(key);
        }
    }
}
