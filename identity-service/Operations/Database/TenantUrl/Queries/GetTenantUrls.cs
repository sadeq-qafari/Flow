using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantUrl.Dtos;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.TenantUrl.Queries
{
    public class GetTenantUrls : DbOperationAsync<int, Dictionary<string, string>>
    {
        protected override async Task ExecutionAsync()
        {
            var urls = (await NewSql(sql => sql.Select("[Identity].[TenantUrl]")
                    .Where("TenantId=@TenantId AND IsDeleted=0").OrderBy("IsDefault DESC"),
                new {TenantId = Input}).QueryAsync<TenantUrl>()).ToList();
            Output = new Dictionary<string, string>();
            foreach (var tenantUrl in urls)
            {
                var key = ((UrlType) tenantUrl.TypeLookup).ToString();
                var index = Output.Keys.Count(x => x.StartsWith(key));
                Output.Add($"{key}{(index > 0 ? index : "")}", tenantUrl.Url);
            }
        }
    }
}
