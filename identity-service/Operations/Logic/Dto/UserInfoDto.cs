using System.Collections.Generic;
using Identity.Operations.Database.TenantUser.Dtos;
using Saanaa.Core.AspNetCore.Operations.Db.UserPermissions.Dto;

namespace Identity.Operations.Logic.Dto
{
    public class UserInfoDto
    {
        public IEnumerable<UserTenantDto>? Tenants { get; set; }
        public Dictionary<string, object?>? Claims { get; set; }
        public PermissionStore? Permissions { get; set; }
    }
}
