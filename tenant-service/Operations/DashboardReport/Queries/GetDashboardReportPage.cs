using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;
using Tenant.Operations.DashboardReport.Dtos;

namespace Tenant.Operations.DashboardReport.Queries
{
    public class GetDashboardReportPage : SaanaaDbQueryPage<DashboardReportDto>
    {
        public GetDashboardReportPage() : base("[Tenant].[DashboardReport]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Tenant].[DashboardReport] DashboardReport", isForCount ? "COUNT(*)" : @"
						DashboardReport.*, 
						Report.Title AS ReportTitle")
                .LeftJoin("[Tenant].[Report] Report",  "DashboardReport.ReportId = Report.Id  AND  Report.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[DashboardReport].[{fieldName}]";
    }
}