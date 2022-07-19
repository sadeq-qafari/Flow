using System;
using System.Threading.Tasks;
using Meteor.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Core.AspNetCore.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class NeedPermission : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string? _permissionName;
        public string? Policies { get; set; }

        public NeedPermission(string? permissionName = null)
        {
            _permissionName = string.IsNullOrWhiteSpace(permissionName) ? null : permissionName;
        }

        // Check Policies
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var policySucceed = false;
            if (!string.IsNullOrWhiteSpace(Policies))
            {
                var authService = context.HttpContext.RequestServices.GetService<IAuthorizationService>();

                foreach (var policy in Policies.Split(','))
                {
                    var res = await authService!.AuthorizeAsync(context.HttpContext.User, policy);
                    policySucceed = res.Succeeded;
                    if (policySucceed)
                        break;
                }
            }

            const string ownerPermissionName = "Common.Core.Owner";

            context.HttpContext.Items.Add(ownerPermissionName, false);
            var userInfo = context.HttpContext.UserInfo();
            if (userInfo == null)
            {
                if (!policySucceed)
                    context.Result = new UnauthorizedResult();

                return;
            }

            context.HttpContext.Items.Add("UserId", userInfo.Id);
            context.HttpContext.Items.Add("BranchId", userInfo.BranchId);
            context.HttpContext.Items.Add("TenantId", userInfo.TenantId);

            var authorizationProvider = context.HttpContext.RequestServices.GetService<AuthorizationProvider>()
                               ?? throw Errors.InternalError("authorization_provider_not_registered");

            context.HttpContext.Items[ownerPermissionName] =
                await authorizationProvider.HasUserPermissionAsync(userInfo.TenantId, userInfo.BranchId, userInfo.Id,
                    ownerPermissionName);

            var isGranted =
                await authorizationProvider.HasUserPermissionAsync(userInfo.TenantId, userInfo.BranchId, userInfo.Id,
                    _permissionName);

            if (!isGranted && !policySucceed)
                context.Result = new UnauthorizedResult();
        }
    }
}
