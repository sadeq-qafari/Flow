using System.Threading.Tasks;
using Identity.Operations.Logic.Dto;
using Meteor.Operation;
using Meteor.Utils;

namespace Identity.Operations.Logic
{
    public class ValidateTokenHash : OperationAsync<string, UserBranchDto>
    {
        protected override async Task ExecutionAsync()
        {
            var redis = OperationFactory.GetRedisCache();
            var key = $"token-hash:{Input}";

            var tokenHash = await redis.Get(key);
            Output = tokenHash.HasValue ? ((string) tokenHash).FromJson<UserBranchDto>() : null;
        }
    }
}
