using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.AspNetCore.Operations.Db.Identity.Dto;
using Core.AspNetCore.Redis;
using Core.Operations.Menu.Dto;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Core.Operations.Menu.Queries
{
    public class GetMenuByUser : DbOperationAsync<GetMenuByUserInDto, List<GetMenuByUserDto>>
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
            var menus = (await NewSql(sql => sql.Select("[Core].[Menu]")
                    .Where("IsDeleted=0 AND IsActive=1")
                    .OrderBy("[Index] ASC"))
                .QueryAsync<GetMenuByUserDto>()).ToList();

            var userPermissions =
                (await _redisCache.Db.SetMembersAsync(RedisCache.Keys.UserPermissionList(Input.TenantId,
                    Input.BranchId ?? Input.TenantId, Input.ActionBy)))
                .Select(x => (string) x)
                .FirstOrDefault();
            var userPermissionStore = new PermissionStore(userPermissions);

            menus = menus.Where(x => x.PermissionName == null
                                     || userPermissionStore?.HasPermission(x.PermissionName) == true)
                .ToList();

            foreach (var menu in menus.Where(menu => menu.ParentId != null))
                menus.Find(x => x.Id == menu.ParentId)?.Children.Add(menu);

            menus = menus.Where(x => x.ParentId == null).OrderBy(x => x.Index).ToList();
            Output = menus.Where(HasAnyChildWithLink).ToList();
        }

        private static bool HasAnyChildWithLink(GetMenuByUserDto menu) =>
            !string.IsNullOrWhiteSpace(menu.Link) || menu.Children.Any(HasAnyChildWithLink);
    }
}
