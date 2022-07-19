using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.FormLeadData.Dtos;
using Meteor.Operation;

namespace Flow.Operations.FormLeadData.Queries
{
    public class GetFormLeadDataExcel : DbQueryExcel<FormLeadDataDto>
    {
        public GetFormLeadDataExcel() : base("[Flow].[FormLeadData]")
        {
        }
        
        protected override async Task<List<FormLeadDataDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormLeadDataPage>().ExecuteAsync(Input))?.Items;
    }
}