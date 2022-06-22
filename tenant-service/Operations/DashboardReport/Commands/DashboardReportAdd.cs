using Saanaa.Core.Meteor;
using Tenant.Operations.DashboardReport.Dtos;

namespace Tenant.Operations.DashboardReport.Commands
{
    public class DashboardReportAdd : SaanaaDbInsertAsync<DashboardReportAddInDto>
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

