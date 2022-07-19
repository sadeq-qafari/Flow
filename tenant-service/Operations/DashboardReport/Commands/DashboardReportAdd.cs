using Core.Meteor;
using Tenant.Operations.DashboardReport.Dtos;

namespace Tenant.Operations.DashboardReport.Commands
{
    public class DashboardReportAdd : DbInsertAsync<DashboardReportAddInDto>
    {
        public DashboardReportAdd() : base("[Tenant].[DashboardReport]",
            @"[ReportId],
						[Index],
						[Parameters]",
            @"@ReportId,
						@Index,
						@Parameters")
        {
        }
    }
}

