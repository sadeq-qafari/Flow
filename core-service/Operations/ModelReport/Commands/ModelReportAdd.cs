using Core.Meteor;
using Core.Operations.ModelReport.Dtos;

namespace Core.Operations.ModelReport.Commands
{
    public class ModelReportAdd : DbInsertAsync<ModelReportAddInDto>
    {
        public ModelReportAdd() : base("[Core].[ModelReport]",
            @"[ModelId],
						[Title],
						[Description],
						[Layout],
						[IsLocked],
						[ReportId]",
            @"@ModelId,
						@Title,
						@Description,
						@Layout,
						@IsLocked,
						@ReportId")
        {
        }
    }
}

