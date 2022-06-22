using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.ServiceConfig.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ServiceConfig.Queries
{
    public class GetServiceConfigExcel : SaanaaDbQueryExcel<ServiceConfigDto>
    {
        public GetServiceConfigExcel() : base("[Core].[ServiceConfig]")
        {
        }
        
        protected override async Task<List<ServiceConfigDto>?> GetItems() =>
            (await OperationFactory!.New<GetServiceConfigPage>().ExecuteAsync(Input))?.Items;
    }
}