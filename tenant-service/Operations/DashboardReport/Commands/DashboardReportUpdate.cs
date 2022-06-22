using Saanaa.Core.Meteor;
using Tenant.Operations.DashboardReport.Dtos;

namespace Tenant.Operations.DashboardReport.Commands
{
    public class DashboardReportUpdate : SaanaaDbUpdateAsync<DashboardReportUpdateInDto>
    {
        public DashboardReportUpdate() : base("[Tenant].[DashboardReport]",
            @"[ReportId]=@ReportId,
					[Index]=@Index,
					[Parameters]=@Parameters")
        {
        }
    }
}