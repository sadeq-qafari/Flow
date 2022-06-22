using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Application.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.Application.Queries
{
    public class GetApplicationExcel : SaanaaDbQueryExcel<ApplicationDto>
    {
        public GetApplicationExcel() : base("[Core].[Application]")
        {
        }
        
        protected override async Task<List<ApplicationDto>?> GetItems() =>
            (await OperationFactory!.New<GetApplicationPage>().ExecuteAsync(Input))?.Items;
    }
}