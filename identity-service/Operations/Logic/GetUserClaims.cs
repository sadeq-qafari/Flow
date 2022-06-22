using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantUser.Queries;
using Identity.Operations.Database.User.Queries;
using Identity.Operations.Database.UserRole.Queries;
using Identity.Operations.Logic.Dto;
using IdentityModel;
using Meteor.Operation.Db;

namespace Identity.Operations.Logic
{
    public class GetUserClaims : DbOperationAsync<UserBranchDto, IEnumerable<Claim>>
    {
        protected override async Task ExecutionAsync()
        {
            var user = await New<GetUser>().ExecuteAsync(Input.UserId);
            if (user == null)
            {
                Output = null;
                return;
            }
            var userTenant = await New<GetUserTenant>().ExecuteAsync(Input);
            if (userTenant == null)
            {
                Output = null;
                return;
            }

            var tenantUrl = userTenant.BaseUrls!.First().Value;
            var roleIds = await New<GetUserRoleIds>().ExecuteAsync(Input);
            var claims = new List<Claim>
            {
                new Claim("username", user.UserName!),
                new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed.ToString()),
                new Claim(JwtClaimTypes.PhoneNumberVerified, user.PhoneNumberConfirmed.ToString())
            };
            if (!string.IsNullOrEmpty(user.FirstName))
                claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));

            if (!string.IsNullOrEmpty(user.LastName))
                claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));

            if (!string.IsNullOrEmpty(user.Email))
                claims.Add(new Claim(JwtClaimTypes.Email, user.Email));

            if (!string.IsNullOrEmpty(user.PhoneNumber))
                claims.Add(new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber));

            claims.Add(new Claim("tenant_id", Input.TenantId.ToString(), ClaimValueTypes.Integer));
            claims.Add(new Claim("tenant_url", tenantUrl));
            claims.Add(new Claim("branch_id", Input.BranchId.ToString(), ClaimValueTypes.Integer));

            if (roleIds != null)
                claims.AddRange(roleIds.Select(x => new Claim("role", x.ToString(), ClaimValueTypes.Integer)));

            Output = claims;
        }
    }
}
