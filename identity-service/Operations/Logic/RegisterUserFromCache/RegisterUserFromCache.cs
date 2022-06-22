using System.Threading.Tasks;
using Identity.Operations.Database.User.Commands;
using Identity.Operations.Database.User.Dtos;
using Identity.Operations.Logic.ValidateVerificationCode.Dto;
using Meteor.Operation;
using Meteor.Utils;
using Saanaa.Core.AspNetCore.Redis;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Logic.RegisterUserFromCache
{
    public class RegisterUserFromCache : OperationAsync<ValidateVerificationCodeInDto, bool>, INeedLog, IHaveTableName
    {
        public string TableName { get; set; } = "[Identity].[User]";

        protected override async Task ExecutionAsync()
        {
            var redis = OperationFactory?.GetService<RedisCache>()
                        ?? throw Errors.InvalidOperation("redis_is_not_registered");
            var isCodeCorrect =
                await New<ValidateVerificationCode.ValidateVerificationCode>().ExecuteAsync(Input);
            if (!isCodeCorrect)
                throw Errors.InvalidInput("invalid_code");

            var key = $"user:register:{Input.Username}";
            var userInfoValue = await redis.Get(key);
            if (!userInfoValue.HasValue)
                throw Errors.InternalError("redis_get_empty");

            var userInfo = ((string)userInfoValue).FromJson<UserRegisterInDto>();
            Output = await New<RegisterUser>().ExecuteAsync(userInfo) > 0;
        }
    }
}
