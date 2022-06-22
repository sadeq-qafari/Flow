using Saanaa.Core.Meteor.Dto;

namespace Core.Operations.Report.Dtos
{
    public class ReportSaveTemplateInDto : SaanaaDbUpdateInDto
    {
        public string Name { get; set; }
        public string Template { get; set; }
    }
}
