using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.Report.Dtos;
using Meteor.Operation;

namespace Core.Operations.Report.Queries
{
    public class GetReportExcel : DbQueryExcel<ReportDto>
    {
        public GetReportExcel() : base("[Core].[Report]")
        {
        }
        
        protected override async Task<List<ReportDto>?> GetItems() =>
            (await OperationFactory!.New<GetReportPage>().ExecuteAsync(Input))?.Items;
    }
}