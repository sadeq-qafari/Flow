using System.Data;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Core.Meteor;
using Tenant.Operations.Dashboard.Dtos;

namespace Tenant.Operations.Dashboard.Commands
{
    public class DashboardUpsert : DbOperationAsync<DashboardUpsertInDto, int>,INeedLog,IHaveTableName
    {
        public string TableName { get; set; } = "[Tenant].[Dashboard]";
        protected override async Task ExecutionAsync()
        {
            Output = await EnsureInTransactionAsync(async () =>
            {
                var res = await NewSql(@"EXECUTE Tenant.sp_DashboardUpsert
                                            @DashboardId = @DashboardId
                                           ,@DashboardTitle = @DashboardTitle
                                           ,@ReportIds = @ReportIds
                                           ,@ActionBy = @ActionBy
                                           ,@TenantId = @TenantId").QueryFirstOrDefaultAsync<int>();

                return res;
            }, IsolationLevel.ReadCommitted);
        }

    }
}
