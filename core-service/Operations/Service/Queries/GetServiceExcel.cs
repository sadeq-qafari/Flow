using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.Service.Dto;
using Meteor.Operation;

namespace Core.Operations.Service.Queries
{
    public class GetServiceExcel : DbQueryExcel<ServiceDto>
    {
        public GetServiceExcel() : base("[Core].[Service]")
        {
        }
        
        protected override async Task<List<ServiceDto>?> GetItems() =>
            (await OperationFactory!.New<GetServicePage>().ExecuteAsync(Input))?.Items;
    }
}