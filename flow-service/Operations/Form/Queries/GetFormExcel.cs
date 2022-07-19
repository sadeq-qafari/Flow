using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.Form.Dtos;
using Meteor.Operation;

//

namespace Flow.Operations.Form.Queries
{
    public class GetFormExcel : DbQueryExcel<FormDto>
    {
        public GetFormExcel() : base("[Flow].[Form]")
        {
        }
        
        protected override async Task<List<FormDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormPage>().ExecuteAsync(Input))?.Items;
    }
}