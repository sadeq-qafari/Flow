using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.DashboardReport.Dtos
{
    public class DashboardReportUpdateInDto : SaanaaDbUpdateInDto
    {
        public int ReportId { get; set; }
        public int Index { get; set; }
        public string? Parameters { get; set; }

    }
}
