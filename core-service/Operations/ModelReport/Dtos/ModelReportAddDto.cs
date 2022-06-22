using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.ModelReport.Dtos
{
    public class ModelReportAddInDto : SaanaaDbInsertInDto
    {
        public int ModelId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Layout { get; set; }
        public bool? IsLocked { get; set; }
        public int? ReportId { get; set; }

    }
}
