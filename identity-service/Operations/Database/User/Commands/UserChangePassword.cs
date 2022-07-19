using System.Threading.Tasks;
using Identity.Operations.Database.User.Dtos;
using Identity.Operations.Database.User.Queries;
using Meteor.Operation.Db;
using Meteor.Utils;
using Core.Meteor;

namespace Identity.Operations.Database.User.Commands
{
    public class UserChangePassword : DbOperationAsync<UserChangePasswordInDto, bool>,INeedLog,IHaveTableName
    {
        public string TableName { get; set; } = "[Identity].[User]";
        protected override Task<UserChangePasswordInDto> PrepareInputAsync()
        {
            Input.NewPassword = PasswordHash.Hash(Input.NewPassword);
            return Task.FromResult(Input);
        }

        protected override async Task ExecutionAsync()
        {
            var user = await New<GetUser>().ExecuteAsync(Input.ActionBy);
            if (user == null)
                throw Errors.InvalidInput("user_id");

            Output = PasswordHash.Validate(Input.Password, user.PasswordHash!)
                     && await NewSql(sql => sql
                             .Update("[Identity].[User]",
                             "[PasswordHash]=@NewPassword").WhereThisId(),new
                                 {Id=Input.ActionBy,Input.NewPassword}
                             )
                         .ExecuteAsync()
                         .ValidateDatabaseAffectedRows() > 0;
        }

    }
}
