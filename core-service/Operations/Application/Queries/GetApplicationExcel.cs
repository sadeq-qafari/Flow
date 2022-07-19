using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.Application.Dtos;
using Meteor.Operation;

namespace Core.Operations.Application.Queries
{
    public class GetApplicationExcel : DbQueryExcel<ApplicationDto>
    {
        public GetApplicationExcel() : base("[Core].[Application]")
        {
        }
        
        protected override async Task<List<ApplicationDto>?> GetItems() =>
            (await OperationFactory!.New<GetApplicationPage>().ExecuteAsync(Input))?.Items;
    }
}