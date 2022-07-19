using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.FormLeadLog.Dtos;
using Meteor.Operation;

namespace Flow.Operations.FormLeadLog.Queries
{
    public class GetFormLeadLogExcel : DbQueryExcel<FormLeadLogDto>
    {
        public GetFormLeadLogExcel() : base("[Flow].[FormLeadLog]")
        {
        }
        
        protected override async Task<List<FormLeadLogDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormLeadLogPage>().ExecuteAsync(Input))?.Items;
    }
}