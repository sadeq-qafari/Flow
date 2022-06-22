using Core.Operations.ModelReport.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelReport.Commands
{
    public class ModelReportUpdate : SaanaaDbUpdateAsync<ModelReportUpdateInDto>
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