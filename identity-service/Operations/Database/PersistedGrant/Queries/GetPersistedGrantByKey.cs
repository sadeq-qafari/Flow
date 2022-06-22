using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetPersistedGrantByKey : DbOperationAsync<string, IdentityServer4.Models.PersistedGrant>
    {
        protected override async Task ExecutionAsync()
        {
            var item = await NewSql(sql => sql
                        .Select("[Identity].[PersistedGrant]")
                        .Where("[Key]=@Key"),
                    new {Key = Input})
                .QueryFirstOrDefaultAsync<PersistedGrant?>();

            if (item != null)
                Output = new IdentityServer4.Models.PersistedGrant
                {
                    ClientId = item.ClientId,
                    ConsumedTime = item.ConsumedTime?.ToDateTimeUtc(),
                    CreationTime = item.CreationTime.ToDateTimeUtc(),
                    Data = item.Data,
                    Description = item.Description,
                    Expiration = item.Expiration?.ToDateTimeUtc(),
                    Key = item.Key,
                    SessionId = item.SessionId,
                    SubjectId = item.SubjectId,
                    Type = item.Type
                };
        }
    }
}
