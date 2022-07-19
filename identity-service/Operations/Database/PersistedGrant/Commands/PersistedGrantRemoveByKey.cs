using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.PersistedGrant.Commands
{
    public class PersistedGrantRemoveByKey : DbOperationAsync<string, bool>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql
                        .Delete("[Identity].[PersistedGrant]")
                        .Where("Key=@Key"),
                    new {Key = Input})
                .ExecuteAsync() > 0;
        }
    }
}
