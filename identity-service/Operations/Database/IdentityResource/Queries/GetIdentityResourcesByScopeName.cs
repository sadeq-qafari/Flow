using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.IdentityResource.Queries
{
    public class GetIdentityResourcesByScopeName : DbOperationAsync<IEnumerable<string>?, IEnumerable<IdentityServer4.Models.IdentityResource>>
    {
        protected override async Task ExecutionAsync()
        {
            var items = await NewSql(sql => sql
                        .Select("[Identity].[IdentityResource]")
                        .Where(x => x.When(Input?.Any() == true, "Name IN @Names")),
                    new {Names = Input})
                .QueryAsync<IdentityResource>();

            Output = items.Select(x => new IdentityServer4.Models.IdentityResource
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
