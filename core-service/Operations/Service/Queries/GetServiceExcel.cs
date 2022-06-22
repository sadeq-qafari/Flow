using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Service.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Service.Queries
{
    public class GetServiceExcel : SaanaaDbQueryExcel<ServiceDto>
    {
        public GetServiceExcel() : base("[Core].[Service]")
        {
        }
        
        protected override async Task<List<ServiceDto>?> GetItems() =>
            (await OperationFactory!.New<GetServicePage>().ExecuteAsync(Input))?.Items;
    }
}