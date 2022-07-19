using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.Tenant.Dtos;
using Identity.Operations.Database.TenantUrl.Queries;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenant : DbOperationAsync<int, TenantDto?>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql
                    .Select("[Identity].[Tenant]")
                    .WhereThisId(), new {Id = Input}
            ).QueryFirstOrDefaultAsync<TenantDto>();
            Output.Urls = await OperationFactory!.New<GetTenantUrls>().ExecuteAsync(Input) ??
                          new Dictionary<string, string>();
        }
    }
}
