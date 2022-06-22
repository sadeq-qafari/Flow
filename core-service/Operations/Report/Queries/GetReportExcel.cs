using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Report.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.Report.Queries
{
    public class GetReportExcel : SaanaaDbQueryExcel<ReportDto>
    {
        public GetReportExcel() : base("[Core].[Report]")
        {
        }
        
        protected override async Task<List<ReportDto>?> GetItems() =>
            (await OperationFactory!.New<GetReportPage>().ExecuteAsync(Input))?.Items;
    }
}