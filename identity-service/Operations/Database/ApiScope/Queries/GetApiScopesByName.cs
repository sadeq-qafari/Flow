using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.ApiScope.Queries
{
    public class GetApiScopesByName : DbOperationAsync<IEnumerable<string>?, IEnumerable<IdentityServer4.Models.ApiScope>>
    {
        protected override async Task ExecutionAsync()
        {
            var items = await NewSql(sql => sql
                        .Select("[Identity].[ApiScope]")
                        .Where(x => x.When(Input?.Any() == true, "Name IN @Names")),
                    new {Names = Input})
                .QueryAsync<ApiScope>();

            Output = items.Select(x => new IdentityServer4.Models.ApiScope
            {
                Description = x.Description,
                DisplayName = x.DisplayName,
                Enabled = x.Enabled,
                Name = x.Name,
                Properties = x.Properties,
                ShowInDiscoveryDocument = x.ShowInDiscoveryDocument,
                UserClaims = x.Claims?.Split(','),
                Emphasize = x.Emphasize,
                Required = x.Required
            });
        }
    }
}
