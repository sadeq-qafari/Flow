using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.FormProperty.Dtos;
using Meteor.Operation;

namespace Flow.Operations.FormProperty.Queries
{
    public class GetFormPropertyExcel : DbQueryExcel<FormPropertyDto>
    {
        public GetFormPropertyExcel() : base("[Flow].[FormProperty]")
        {
        }
        
        protected override async Task<List<FormPropertyDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormPropertyPage>().ExecuteAsync(Input))?.Items;
    }
}