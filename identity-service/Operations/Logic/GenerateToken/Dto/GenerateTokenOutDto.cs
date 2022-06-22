using System.Collections.Generic;
using Identity.Operations.Database.TenantUser.Dtos;
using Saanaa.Core.AspNetCore.Operations.Db.UserPermissions.Dto;

namespace Identity.Operations.Logic.GenerateToken.Dto
{
    public class GenerateTokenOutDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public IEnumerable<UserTenantDto>? Tenants { get; set; }
        public Dictionary<string, object?> Claims { get; set; }
        public PermissionStore? Permissions { get; set; }
    }
}
