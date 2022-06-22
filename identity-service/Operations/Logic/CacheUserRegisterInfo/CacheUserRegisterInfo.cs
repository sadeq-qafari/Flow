using System;
using System.Threading.Tasks;
using Identity.Operations.Database.Branch.Queries;
using Identity.Operations.Database.User.Dtos;
using Identity.Operations.Logic.Dto;
using Meteor.Operation;
using Meteor.Utils;
using Saanaa.Core.AspNetCore.Redis;

namespace Identity.Operations.Logic.CacheUserRegisterInfo
{
    public class CacheUserRegisterInfo : OperationAsync<UserRegisterInDto, bool>
    {
        protected override async Task<UserRegisterInDto> PrepareInputAsync()
        {
            Input.CreatedBy = 0;
            Input.BranchId =
                (await OperationFactory!.New<GetDefaultBranch>()
                    .ExecuteAsync((int) Input.TenantId!))?.Id;
            return Input;
        }

        protected override async Task ExecutionAsync()
        {
            var redis = OperationFactory?.GetService<RedisCache>()
                        ?? throw Errors.InvalidOperation("redis_is_not_registered");
            var key = $"user:register:{Input.Username}";
            if (!await redis.Set(key, Input, TimeSpan.FromMinutes(20)))
                throw Errors.InternalError("redis_set_error");

            Output = await New<SendVerificationCode.SendVerificationCode>().ExecuteAsync(new SendVerificationCodeInDto
            {
                MobileNumber = Input.Username,
                TenantId = Input.TenantId
            });
        }
    }
}
