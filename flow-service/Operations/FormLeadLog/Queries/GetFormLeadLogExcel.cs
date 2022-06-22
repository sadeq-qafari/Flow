using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.FormLeadLog.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadLog.Queries
{
    public class GetFormLeadLogExcel : SaanaaDbQueryExcel<FormLeadLogDto>
    {
        public GetFormLeadLogExcel() : base("[Flow].[FormLeadLog]")
        {
        }
        
        protected override async Task<List<FormLeadLogDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormLeadLogPage>().ExecuteAsync(Input))?.Items;
    }
}