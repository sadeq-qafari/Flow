using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelReport.Dtos;
using Meteor.Operation;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReportExcel : DbQueryExcel<ModelReportDto>
    {
        public GetModelReportExcel() : base("[Core].[ModelReport]")
        {
        }
        
        protected override async Task<List<ModelReportDto>?> GetItems() =>
            (await OperationFactory!.New<GetModelReportPage>().ExecuteAsync(Input))?.Items;
    }
}