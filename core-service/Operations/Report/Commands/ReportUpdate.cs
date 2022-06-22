using Core.Operations.Report.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.Report.Commands
{
    public class ReportUpdate : SaanaaDbUpdateAsync<ReportUpdateInDto>
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
