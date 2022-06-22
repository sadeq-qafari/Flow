using System;
using System.Linq;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantUser.Queries;
using Identity.Operations.Logic;
using Identity.Operations.Logic.Dto;
using Identity.Operations.Logic.ValidateVerificationCode;
using Identity.Operations.Logic.ValidateVerificationCode.Dto;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Meteor.Operation;

namespace Identity.Helper
{
    public class VerificationCodeGrantValidator : IExtensionGrantValidator
    {
        private readonly OperationFactory _operationFactory;

        public string GrantType => "verification_code";

        public VerificationCodeGrantValidator(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var username = context.Request.Raw.Get("username").ToLowerInvariant();
            var isVerified = await _operationFactory.New<ValidateVerificationCode>().ExecuteAsync(
                new ValidateVerificationCodeInDto
                {
                    Username = username,
                    Code = context.Request.Raw.Get("verification_code")
                });

            if (!isVerified)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                return;
            }

            var originUrl = context.Request.Raw["OriginUrl"];
            var userTenants = await _operationFactory.New<GetAllUserTenants>().ExecuteAsync(username);
            var userTenantsWithOrigin = userTenants?.Where(x =>
                x.BaseUrls?.Any(y => y.Value.Contains(originUrl!, StringComparison.InvariantCultureIgnoreCase)) ==
                true).ToList();

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
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                return;
            }

            context.Result = new GrantValidationResult(
                subject: userTenant.UserId.ToString(),
                authenticationMethod: GrantType,
                claims: claims);
        }
    }
}
