using Core.Meteor.Dto;

namespace Core.Operations.Report.Dtos
{
    public class ReportUpdateInDto : DbUpdateInDto
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public bool IsReport { get; set; }

    }
}
