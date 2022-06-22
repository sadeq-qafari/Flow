using System.Threading.Tasks;
using Identity.Operations.Logic.ValidateVerificationCode.Dto;
using Meteor.Operation;

namespace Identity.Operations.Logic.ValidateVerificationCode
{
    public class ValidateVerificationCode : OperationAsync<ValidateVerificationCodeInDto, bool>
    {
        protected override async Task ExecutionAsync()
        {
            var redis = OperationFactory.GetRedisCache();

            var key = $"user:verify-code:{Input.Username}";
            var code = await redis.Get(key);
            Output = code.HasValue && code == Input.Code;
        }
    }
}
