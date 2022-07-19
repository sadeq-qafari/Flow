using System.Collections.Generic;

namespace Tenant.Operations.Report.Dtos
{
    public class ReportDto : Report
    {
        public string? TypeLookupTitle { get; set; }
        public object? Result { get; set; }
        public Dictionary<string,object>? DashboardReportParameters { get; set; }
        public int DashboardIndex { get; set; }
        public int DashboardId { get; set; }
        public string DashboardTitle { get; set; }
    }
}
