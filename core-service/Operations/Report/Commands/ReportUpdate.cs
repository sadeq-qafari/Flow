using Core.Meteor;
using Core.Operations.Report.Dtos;

namespace Core.Operations.Report.Commands
{
    public class ReportUpdate : DbUpdateAsync<ReportUpdateInDto>
    {
        public ReportUpdate() : base("[Core].[Report]",
            @"[Title]=@Title,
					[Name]=@Name,
					[IsReport]=@IsReport,
					[Action]=@Action")
        {
        }
    }
}
