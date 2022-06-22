using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Dashboard.Dtos
{
    public class DashboardAddInDto : SaanaaDbInsertInDto
    {
        public string? Title { get; set; }
        public int? PersonId { get; set; }
        public int Index { get; set; }
        public IntList ReportIds { get; set; }

    }
}
