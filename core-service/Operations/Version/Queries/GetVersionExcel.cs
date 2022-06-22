using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Operations.Version.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Version.Queries
{
    public class GetVersionExcel : SaanaaDbQueryExcel<VersionDto>
    {
        public GetVersionExcel() : base("[Core].[Version]")
        {
        }
        
        protected override async Task<List<VersionDto>?> GetItems() =>
            (await OperationFactory!.New<GetVersionPage>().ExecuteAsync(Input))?.Items;
    }
}