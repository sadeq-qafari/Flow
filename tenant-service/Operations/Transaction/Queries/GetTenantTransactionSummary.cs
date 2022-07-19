using System.Threading.Tasks;
using Meteor.Operation.Db;
using Tenant.Operations.Transaction.Dtos;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTenantTransactionSummary : DbOperationAsync<int?, TenantTransactionSummaryDto?>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE Tenant.sp_TenantTransactionSummary @TenantId = @TenantId",
                new { TenantId = Input }).QueryFirstOrDefaultAsync<TenantTransactionSummaryDto?>();
        }
    }
}
