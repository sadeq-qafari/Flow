using System.Data;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Meteor.Utils;
using Tenant.Operations.Dashboard.Dtos;

namespace Tenant.Operations.Dashboard.Commands
{
    public class DashboardAdd : DbOperationAsync<DashboardAddInDto, long>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await EnsureInTransactionAsync(async () =>
            {
                var dashboardId = await NewSql(sql => sql.InsertReturnId("[Tenant].[Dashboard]",
                    @"
  Title
 ,PersonId
 ,IsActive
 ,IsDeleted
 ,CreatedBy
 ,TenantId", @"
  @Title
 ,@CreatedBy
 ,1
 ,0
 ,@CreatedBy
 ,@TenantId")).ExecuteScalarAsync<long>();

                var sqlText = @"INSERT Tenant.DashboardReport 
(
  DashboardId
 ,ReportId
 ,[Index]
 ,Parameters
 ,IsActive
 ,IsDeleted
 ,CreatedBy
 ,TenantId
)
SELECT @DashboardId
      ,Id
      ,ROW_NUMBER() OVER(ORDER BY ServiceName ASC)
      ,Parameters
      ,1
      ,0
      ,@CreatedBy
      ,@TenantId FROM Tenant.Report
  WHERE Id IN @ReportIds";

                await NewSql(sqlText, new {DashboardId = dashboardId, Input.ReportIds, Input.CreatedBy, Input.TenantId})
                    .ExecuteAsync().ValidateDatabaseAffectedRows();

                return dashboardId;
            }, IsolationLevel.ReadCommitted);
        }
    }
}
