using Core.Meteor.Dto;

namespace Core.Operations.Report.Dtos
{
    public class ReportSaveTemplateInDto : DbUpdateInDto
    {
        public string Name { get; set; }
        public string Template { get; set; }
    }
}
