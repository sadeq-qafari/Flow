using Core.Operations.Report.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.Report.Commands
{
    public class ReportAdd : SaanaaDbInsertAsync<ReportAddInDto>
    {
        public ReportAdd() : base("[Core].[Report]",
            @"[Title],
						[Name],
						[Action],
						[IsReport],
                        [Template]",
            @"@Title,
						@Name,
						@Action,
						@IsReport,
                        N''")
        {
        }
    }
}

