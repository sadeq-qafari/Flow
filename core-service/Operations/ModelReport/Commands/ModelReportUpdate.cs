using Core.Meteor;
using Core.Operations.ModelReport.Dtos;

namespace Core.Operations.ModelReport.Commands
{
    public class ModelReportUpdate : DbUpdateAsync<ModelReportUpdateInDto>
    {
        public ModelReportUpdate() : base("[Core].[ModelReport]",
            @"[ModelId]=@ModelId,
					[Title]=@Title,
					[Description]=@Description,
					[Layout]=@Layout,
					[IsLocked]=@IsLocked,
					[ReportId]=@ReportId")
        {
        }
    }
}