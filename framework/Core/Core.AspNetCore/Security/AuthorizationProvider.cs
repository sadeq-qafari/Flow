using System;
using System.Threading.Tasks;
using Core.AspNetCore.Operations.Db.Identity.Commands;
using Core.AspNetCore.Operations.Db.Identity.Dto;
using Core.AspNetCore.Operations.Db.Identity.Queries;
using Core.AspNetCore.Redis;
using Meteor.Operation;
using Meteor.Utils;

namespace Core.AspNetCore.Security
{
    public class AuthorizationProvider
    {
        private readonly RedisCache _redisService;
        private readonly OperationFactory _operationFactory;

        public AuthorizationProvider(RedisCache redisService, OperationFactory operationFactory)
        {
            _redisService = redisService;
            _operationFactory = operationFactory;
        }

        public async Task<bool> HasUserPermissionAsync(int? tenantId, int? branchId, int userId, string? permissionName)
        {
            var permissionRedisKey = RedisCache.Keys.UserPermissionList(tenantId, branchId, userId);
            if (!await _redisService!.Db.KeyExistsAsync(permissionRedisKey))
                await CacheUserPermissions(tenantId, branchId, userId, permissionRedisKey);

            if (permissionName == null)
                return true;

            return await _operationFactory!.New<CheckPermission>().ExecuteAsync(new CheckPermissionInDto
            {
                PermissionName = permissionName,
                UserId = userId,
                BranchId = branchId,
                TenantId = tenantId
            });
        }

        private async Task CacheUserPermissions(int? tenantId, int? branchId, int userId, string permissionRedisKey)
        {
            var userPermissions = await _operationFactory.New<GetUserPermissions>().ExecuteAsync(new GetUserPermissionsInDto
            {
                BranchId = branchId,
                TenantId = tenantId,
                ActionBy = userId,
            });

            await _redisService.Db.SetAddAsync(permissionRedisKey, userPermissions?.Count <= 0
                ? "{}"
                : userPermissions!.ToJson());

            await _redisService.Db.KeyExpireAsync(permissionRedisKey, TimeSpan.FromHours(1));
        }
    }
}
