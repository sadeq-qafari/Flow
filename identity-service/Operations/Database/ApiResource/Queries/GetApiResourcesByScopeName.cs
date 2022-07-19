using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.ApiResource.Queries
{
    public class GetApiResourcesByScopeName : DbOperationAsync<IEnumerable<string>, IEnumerable<IdentityServer4.Models.ApiResource>>
    {
        protected override async Task ExecutionAsync()
        {
            var items = await NewSql(sql => sql
                        .Select("[Identity].[ApiResource] ar")
                        .Where("EXISTS (SELECT TOP 1 1 FROM STRING_SPLIT(ar.Scopes,',') WHERE VALUE IN @Names)"),
                    new {Names = Input})
                .QueryAsync<ApiResource>();

            Output = items.Select(x => new IdentityServer4.Models.ApiResource
            {
                Description = x.Description,
                DisplayName = x.DisplayName,
                Enabled = x.Enabled,
                Name = x.Name,
                Properties = x.Properties,
                ShowInDiscoveryDocument = x.ShowInDiscoveryDocument,
                UserClaims = x.Claims?.Split(','),
                AllowedAccessTokenSigningAlgorithms = x.AllowedAccessTokenSigningAlgorithms?.Split(','),
                ApiSecrets = x.Secrets,
                Scopes = x.Scopes?.Split(',')
            });
        }
    }
}
