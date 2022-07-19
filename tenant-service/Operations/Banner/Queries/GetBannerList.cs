using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Tenant.Operations.Banner.Queries
{
    public class GetBannerList : DbOperationAsync<int, IEnumerable<Banner>>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(
                    sql => sql.Select("[Tenant].[Banner]")
                        .Where("TenantId = @TenantId AND IsDeleted = 0 AND IsActive = 1").OrderBy("[Index]"),
                    new {TenantId = Input})
                .QueryAsync<Banner>();
        }
    }
}
