using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Stores;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.PersistedGrant.Queries
{
    public class GetAllPersistedGrants : DbOperationAsync<PersistedGrantFilter, IEnumerable<IdentityServer4.Models.PersistedGrant>>
    {
        protected override async Task ExecutionAsync()
        {
            var items = await NewSql(sql => sql
                        .Select("[Identity].[PersistedGrant]")
                        .Where(x => x
                            .When(!string.IsNullOrWhiteSpace(Input.ClientId), "ClientId=@ClientId")
                            .When(!string.IsNullOrWhiteSpace(Input.SessionId), "SessionId=@SessionId")
                            .When(!string.IsNullOrWhiteSpace(Input.SubjectId), "SubjectId=@SubjectId")
                            .When(!string.IsNullOrWhiteSpace(Input.Type), "Type=@Type")))
                .QueryAsync<PersistedGrant?>();

            Output = items.Select(item => new IdentityServer4.Models.PersistedGrant
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
            });
        }
    }
}
