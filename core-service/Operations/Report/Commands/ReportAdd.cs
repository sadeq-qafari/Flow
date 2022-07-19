using Core.Meteor;
using Core.Operations.Report.Dtos;

namespace Core.Operations.Report.Commands
{
    public class ReportAdd : DbInsertAsync<ReportAddInDto>
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

