using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.FormAction.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormAction.Queries
{
    public class GetFormActionExcel : SaanaaDbQueryExcel<FormActionDto>
    {
        public GetFormActionExcel() : base("[Flow].[FormAction]")
        {
        }
        
        protected override async Task<List<FormActionDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormActionPage>().ExecuteAsync(Input))?.Items;
    }
}