using System.Threading.Tasks;
using Identity.Operations.Database.User.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Identity.Operations.Database.User.Queries
{
    public class GetUserByPassword : DbOperationAsync<UsernamePasswordDto, UserDto>
    {
        protected override async Task ExecutionAsync()
        {
            var user = await NewSql(sql => sql
                    .Select("[Identity].[User]")
                    .Where("Username=@Username"))
                .QueryFirstOrDefaultAsync<UserDto?>();

            if (user == null)
                throw Errors.InvalidInput("username");

            Output = PasswordHash.Validate(Input.Password, user.PasswordHash!) ? user : null;
        }
    }
}
