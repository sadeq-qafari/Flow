using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ModelReport.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReportExcel : SaanaaDbQueryExcel<ModelReportDto>
    {
        public GetModelReportExcel() : base("[Core].[ModelReport]")
        {
        }
        
        protected override async Task<List<ModelReportDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelReportPage>().ExecuteAsync(Input))?.Items;
    }
}