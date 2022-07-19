using System.Threading.Tasks;
using Identity.Operations.Database.User.Dtos;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.User.Commands
{
    public class UserAdd : DbOperationAsync<UserAddInDto, long>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await OperationFactory!
                .New<RegisterUser>()
                .ExecuteAsync(Input);
        }
    }
}
