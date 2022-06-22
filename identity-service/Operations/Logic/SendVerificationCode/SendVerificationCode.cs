using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.Tenant.Queries;
using Identity.Operations.Logic.Dto;
using Meteor.Operation;
using Meteor.Utils;
using Saanaa.Core.AspNetCore.Operations.Logic.SendMessage;
using Saanaa.Core.AspNetCore.Operations.Logic.SendMessage.Dto;
using Saanaa.Core.AspNetCore.Redis;

namespace Identity.Operations.Logic.SendVerificationCode
{
    public class SendVerificationCode : OperationAsync<SendVerificationCodeInDto, bool>
    {
        private static readonly Random RandomNumber = new();

        protected override async Task ExecutionAsync()
        {
            var redis = OperationFactory?.GetService<RedisCache>()
                        ?? throw Errors.InvalidOperation("redis_is_not_registered");

            var tenant = Input.TenantId > 0
                ? (await OperationFactory.New<GetTenant>().ExecuteAsync((int) Input.TenantId!))
                  ?? throw Errors.InvalidInput("wrong_tenant")
                : (await OperationFactory.New<GetTenantByUrl>().ExecuteAsync(Input.TenantUrl!))
                  ?? throw Errors.InvalidInput("wrong_tenant");

            var smsHash = "";
            //TODO: Set the smsHash dynamically
            if (tenant.Urls["WebSite"]?.ToLowerInvariant()?.Contains("hamiane") == true)
            {
                smsHash = "w5PmQuojeWP";
            }

            var key = $"user:verify-code:{Input.MobileNumber}";
            var verificationCode = RandomNumber.Next(10000, 99999);
            await redis.Set(key, verificationCode.ToString(), TimeSpan.FromMinutes(2));

            var smsId = await OperationFactory!.New<SendMessage>().ExecuteAsync(new SendMessageInDto()
            {
                MessageName = "IdentityAccountVerifyUser",
                Receivers = Input.MobileNumber,
                TenantId = tenant.Id,
                Params = new List<string>()
                {
                    verificationCode.ToString(),
                    smsHash,
                    "",
                    tenant!.Title
                }
            });
            Output = true;
        }
    }
}
