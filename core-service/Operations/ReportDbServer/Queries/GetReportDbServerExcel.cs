using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ReportDbServer.Dtos;
using Meteor.Operation;

namespace Core.Operations.ReportDbServer.Queries
{
    public class GetReportDbServerExcel : DbQueryExcel<ReportDbServerDto>
    {
        public GetReportDbServerExcel() : base("[Core].[ReportDbServer]")
        {
        }
        
        protected override async Task<List<ReportDbServerDto>?> GetItems() =>
            (await OperationFactory!.New<GetReportDbServerPage>().ExecuteAsync(Input))?.Items;
    }
}