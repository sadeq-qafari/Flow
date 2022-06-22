using System;
using System.Linq;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantUser.Queries;
using Identity.Operations.Database.User.Dtos;
using Identity.Operations.Database.User.Queries;
using Identity.Operations.Logic;
using Identity.Operations.Logic.Dto;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Meteor.Operation;

namespace Identity.Helper
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly OperationFactory _operationFactory;

        public string GrantType => "password";

        public ResourceOwnerPasswordValidator(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var originUrl = context.Request.Raw["OriginUrl"];
                if (string.IsNullOrWhiteSpace(originUrl))
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid_origin");
                    return;
                }

                var user = await _operationFactory.New<GetUserByPassword>().ExecuteAsync(new UsernamePasswordDto
                {
                    Username = context.UserName,
                    Password = context.Password
                });
                if (user == null)
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid_credentials");
                    return;
                }

                var userTenants = await _operationFactory.New<GetAllUserTenants>().ExecuteAsync(context.UserName);
                var userTenantsWithOrigin = userTenants?
                    .Where(x => x.BaseUrls?.Any(y => y.Value.Contains(originUrl, StringComparison.InvariantCultureIgnoreCase)) ==
                                true)
                    .ToList();
                if (userTenantsWithOrigin == null || !userTenantsWithOrigin.Any())
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid_tenant_or_banned");
                    return;
                }

                var userTenant = userTenantsWithOrigin.FirstOrDefault(x => x.IsDefault) ?? userTenantsWithOrigin.First();
                var claims = await _operationFactory.New<GetUserClaims>().ExecuteAsync(new UserBranchDto
                {
                    TenantId = userTenant.Id,
                    BranchId = userTenant.BranchId,
                    UserId = userTenant.UserId
                });
                if (claims == null)
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "no_claims");
                    return;
                }

                context.Result = new GrantValidationResult(
                    subject: userTenant.UserId.ToString(),
                    authenticationMethod: GrantType,
                    claims: claims);
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, ex.Message);
            }
        }
    }
}
