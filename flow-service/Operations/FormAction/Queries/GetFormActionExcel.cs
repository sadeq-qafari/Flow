using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.FormAction.Dtos;
using Meteor.Operation;

namespace Flow.Operations.FormAction.Queries
{
    public class GetFormActionExcel : DbQueryExcel<FormActionDto>
    {
        public GetFormActionExcel() : base("[Flow].[FormAction]")
        {
        }
        
        protected override async Task<List<FormActionDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormActionPage>().ExecuteAsync(Input))?.Items;
    }
}