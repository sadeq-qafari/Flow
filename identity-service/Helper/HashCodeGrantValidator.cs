using System.Threading.Tasks;
using Identity.Operations.Logic;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Meteor.Operation;

namespace Identity.Helper
{
    public class HashCodeGrantValidator : IExtensionGrantValidator
    {
        private readonly OperationFactory _operationFactory;

        public string GrantType => "hash_code";

        public HashCodeGrantValidator(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var hash = context.Request.Raw.Get("hash");

            if (string.IsNullOrWhiteSpace(hash))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                return;
            }

            var userBranch = await _operationFactory.New<ValidateTokenHash>().ExecuteAsync(hash);
            if (userBranch == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                return;
            }

            var claims = await _operationFactory.New<GetUserClaims>().ExecuteAsync(userBranch);
            if (claims == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                return;
            }

            context.Result = new GrantValidationResult(
                subject: userBranch.UserId.ToString(),
                authenticationMethod: GrantType,
                claims: claims);
        }
    }
}
