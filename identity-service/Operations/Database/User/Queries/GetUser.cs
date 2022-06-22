using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.User.Queries
{
    public class GetUser : DbOperationAsync<int, User>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql
                    .Select("[Identity].[User]")
                    .WhereThisId(), new {Id = Input})
                .QueryFirstOrDefaultAsync<User>();
        }
    }
}
