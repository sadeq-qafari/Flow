using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.Tenant.Dtos;
using Identity.Operations.Database.TenantUrl.Queries;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.Tenant.Queries
{
    public class GetTenantByUrl : DbOperationAsync<string, TenantDto>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql
                    .Select("[Identity].[Tenant] Tenant","Tenant.*")
                    .InnerJoin("[Identity].[TenantUrl] TenantUrl","TenantUrl.TenantId = Tenant.Id")
                    .Where("TenantUrl.Url LIKE N'%'+@TenantUrl+N'%'")
                , new {TenantUrl = Input}
            ).QueryFirstOrDefaultAsync<TenantDto>();

            Output.Urls = await OperationFactory!.New<GetTenantUrls>().ExecuteAsync(Output.Id) ??
                          new Dictionary<string, string>();
        }
    }
}
