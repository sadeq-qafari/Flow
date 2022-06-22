using Core.Operations.ModelReport.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelReport.Commands
{
    public class ModelReportAdd : SaanaaDbInsertAsync<ModelReportAddInDto>
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

