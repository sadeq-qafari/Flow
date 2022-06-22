using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.FormPermission.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormPermission.Queries
{
    public class GetFormPermissionExcel : SaanaaDbQueryExcel<FormPermissionDto>
    {
        public GetFormPermissionExcel() : base("[Flow].[FormPermission]")
        {
        }
        
        protected override async Task<List<FormPermissionDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormPermissionPage>().ExecuteAsync(Input))?.Items;
    }
}