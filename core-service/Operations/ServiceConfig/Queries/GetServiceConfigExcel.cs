using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ServiceConfig.Dto;
using Meteor.Operation;

namespace Core.Operations.ServiceConfig.Queries
{
    public class GetServiceConfigExcel : DbQueryExcel<ServiceConfigDto>
    {
        public GetServiceConfigExcel() : base("[Core].[ServiceConfig]")
        {
        }
        
        protected override async Task<List<ServiceConfigDto>?> GetItems() =>
            (await OperationFactory!.New<GetServiceConfigPage>().ExecuteAsync(Input))?.Items;
    }
}