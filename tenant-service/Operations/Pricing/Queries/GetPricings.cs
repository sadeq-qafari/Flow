using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Tenant.Operations.Pricing.Queries
{
    public class GetPricings : DbOperationAsync<int, IEnumerable<Pricing>>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql =>
                    sql.Select("[Tenant].[Pricing]")
                        .Where("ApplicationId=@ApplicationId AND IsActive=1 AND IsDeleted=0")
                        .OrderBy("FinalPrice"), new { ApplicationId = Input })
                .QueryAsync<Pricing>();
        }
    }
}
