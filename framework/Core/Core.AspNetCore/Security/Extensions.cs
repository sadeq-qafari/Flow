using System;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.AspNetCore.Security
{
    public static class Extensions
    {
        public static UserInfo? UserInfo(this HttpContext context)
        {
            if (context.User.Identity == null || !context.User.Identity.IsAuthenticated)
                return null;

            if (!context.User.HasClaim(x => x.Type == "sub"))
                return null;

            var tenantId = context.User.FindFirst("tenant_id")?.Value;
            var branchId = context.User.FindFirst("branch_id")?.Value;
            return new UserInfo
            {
                Id = int.Parse(context.User.FindFirst("sub").Value),
                UserName = context.User.FindFirst("username").Value,
                FirstName = context.User.FindFirst(JwtClaimTypes.GivenName)?.Value,
                LastName = context.User.FindFirst(JwtClaimTypes.FamilyName)?.Value,
                Email = context.User.FindFirst(JwtClaimTypes.Email)?.Value,
                EmailConfirmed = bool.Parse(context.User.FindFirst(JwtClaimTypes.EmailVerified).Value),
                PhoneNumber = context.User.FindFirst(JwtClaimTypes.PhoneNumber)?.Value,
                PhoneNumberConfirmed = bool.Parse(context.User.FindFirst(JwtClaimTypes.PhoneNumberVerified).Value),
                BranchId = branchId != null ? int.Parse(branchId) : (int?) null,
                TenantId = tenantId != null ? int.Parse(tenantId) : (int?) null
            };
        }

        public static IServiceCollection AddSqSecurityService(this IServiceCollection services,
            Action<SecurityOptions> config)
        {
            services.AddHttpClient();
            services.Configure(config);
            return services;
        }
    }
}
