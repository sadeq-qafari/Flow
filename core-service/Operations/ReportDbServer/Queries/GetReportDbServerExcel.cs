using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ReportDbServer.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.ReportDbServer.Queries
{
    public class GetReportDbServerExcel : SaanaaDbQueryExcel<ReportDbServerDto>
    {
        public GetReportDbServerExcel() : base("[Core].[ReportDbServer]")
        {
        }
        
        protected override async Task<List<ReportDbServerDto>?> GetItems() =>
            (await OperationFactory!.New<GetReportDbServerPage>().ExecuteAsync(Input))?.Items;
    }
}