using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.FormProperty.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormProperty.Queries
{
    public class GetFormPropertyExcel : SaanaaDbQueryExcel<FormPropertyDto>
    {
        public GetFormPropertyExcel() : base("[Flow].[FormProperty]")
        {
        }
        
        protected override async Task<List<FormPropertyDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormPropertyPage>().ExecuteAsync(Input))?.Items;
    }
}