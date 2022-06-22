using Saanaa.Core.Meteor.Dto;

namespace Tenant.Operations.Report.Dtos
{
    public class ReportAddInDto : SaanaaDbInsertInDto
    {
        public string? Title { get; set; }
        public string Name { get; set; }
        public int TypeLookup { get; set; }
        public string ServiceName { get; set; }
        public string PermissionName { get; set; }
        public string? Link { get; set; }
        public int Size { get; set; }
        public string Query { get; set; }
        public string? Parameters { get; set; }

    }
}
