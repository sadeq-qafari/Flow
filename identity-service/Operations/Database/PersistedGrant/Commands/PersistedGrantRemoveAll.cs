using System.Threading.Tasks;
using IdentityServer4.Stores;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.PersistedGrant.Commands
{
    public class PersistedGrantRemoveAll : DbOperationAsync<PersistedGrantFilter, bool>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql
                        .Delete("[Identity].[PersistedGrant]")
                        .Where(x => x
                            .When(!string.IsNullOrWhiteSpace(Input.ClientId), "ClientId=@ClientId")
                            .When(!string.IsNullOrWhiteSpace(Input.SessionId), "SessionId=@SessionId")
                            .When(!string.IsNullOrWhiteSpace(Input.SubjectId), "SubjectId=@SubjectId")
                            .When(!string.IsNullOrWhiteSpace(Input.Type), "Type=@Type")),
                    new {Key = Input})
                .ExecuteAsync() > 0;
        }
    }
}
