namespace Core.Operations.ModelReport.Dtos
{
    public class ModelReportInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Layout { get; set; }
        public bool? IsLocked { get; set; }
        public string? ReportName { get; set; }
        public string? ModelName { get; set; }
        public string? ServiceName { get; set; }
        public bool IsReport { get; set; }
    }
}
