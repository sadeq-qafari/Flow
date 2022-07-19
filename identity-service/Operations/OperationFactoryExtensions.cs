using Meteor.Operation;
using Meteor.Utils;
using Core.AspNetCore.Redis;

namespace Identity.Operations
{
    public static class OperationFactoryExtensions
    {
        public static RedisCache GetRedisCache(this OperationFactory? operationFactory) =>
            operationFactory?.GetService<RedisCache>()
            ?? throw Errors.InternalError("redis_service_is_not_registered");
    }
}
