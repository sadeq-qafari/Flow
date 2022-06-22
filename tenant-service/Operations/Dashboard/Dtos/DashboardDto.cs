using System.Collections.Generic;
using Tenant.Operations.Report.Dtos;

namespace Tenant.Operations.Dashboard.Dtos
{
    public class DashboardDto : Dashboard
    {
        public string? PersonTitle { get; set; }
        public List<ReportDto> Reports { get; set; }
    }
}
