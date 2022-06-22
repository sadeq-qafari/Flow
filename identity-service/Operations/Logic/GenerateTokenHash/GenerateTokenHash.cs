using System;
using System.Threading.Tasks;
using Identity.Operations.Database.Branch.Queries;
using Identity.Operations.Logic.Dto;
using Meteor.Operation.Db;
using Meteor.Utils;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Logic.GenerateTokenHash
{
    public class GenerateTokenHash : DbOperationAsync<UserBranchDto, string>, INeedLog, IHaveTableName
    {
        public string TableName { get; set; } = "[Identity].[Token]";

        protected override async Task<UserBranchDto> PrepareInputAsync()
        {
            if (Input?.BranchId == null || Input.BranchId == 0)
            {
                Input.BranchId =
                    (int)(await OperationFactory!.New<GetDefaultBranch>()
                        .ExecuteAsync((int)Input.TenantId!))?.Id!;
            }

            return Input;
        }

        protected override async Task ExecutionAsync()
        {
            Output = $"{(Input.UserId.ToString() + Guid.NewGuid()).GetHashCode():X}";

            var key = $"token-hash:{Output}";
            if (!await OperationFactory.GetRedisCache().Set(key, Input, TimeSpan.FromHours(24)))
                throw Errors.InternalError("redis_set_error");
        }
    }
}
