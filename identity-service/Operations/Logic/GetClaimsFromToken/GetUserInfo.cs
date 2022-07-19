using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantUser.Queries;
using Identity.Operations.Database.User.Dtos;
using Identity.Operations.Database.User.Queries;
using Identity.Operations.Logic.Dto;
using Meteor.Operation;

namespace Identity.Operations.Logic.GetClaimsFromToken
{
    public class GetUserInfo : OperationAsync<string, UserInfoDto>
    {
        protected override async Task ExecutionAsync()
        {
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(Input).Claims.GroupBy(x => x.Type).ToDictionary(
                x => x.Key,
                x =>
                {
                    var items = x.Select(y => y.Value)?.ToList();
                    if (items?.Count > 1)
                        return (object) items;
                    else
                        return items?.FirstOrDefault();
                });
            var username = claims.GetValueOrDefault("username", "").ToString();
            var tenants = !string.IsNullOrWhiteSpace(username)
                ? await New<GetAllUserTenants>().ExecuteAsync(username)
                : null;
            var permissions = await New<GetUserPermissions>().ExecuteAsync(new GetUserPermissionsInDto
            {
                ActionBy = int.Parse(claims.GetValueOrDefault("sub", "0")?.ToString() ?? "0"),
                TenantId = int.Parse(claims.GetValueOrDefault("tenant_id", "0")?.ToString() ?? "0"),
                BranchId = int.Parse(claims.GetValueOrDefault("branch_id", "0")?.ToString() ?? "0")
            });

            Output = new UserInfoDto
            {
                Tenants = tenants,
                Claims = claims,
                Permissions = permissions
            };
        }
    }
}
