using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Identity.Operations.Database.Branch.Queries
{
    public class GetDefaultBranch : DbOperationAsync<int, Branch>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.Select("[Identity].[Branch] Branch")
                    .Where("Branch.TenantId = @TenantId AND ParentId IS NULL")
                    .OrderBy("Id ASC")
                , new {TenantId = Input}
            ).QueryFirstOrDefaultAsync<Branch>();
        }
    }
}
