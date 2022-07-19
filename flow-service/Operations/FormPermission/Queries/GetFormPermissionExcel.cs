using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.FormPermission.Dtos;
using Meteor.Operation;

namespace Flow.Operations.FormPermission.Queries
{
    public class GetFormPermissionExcel : DbQueryExcel<FormPermissionDto>
    {
        public GetFormPermissionExcel() : base("[Flow].[FormPermission]")
        {
        }
        
        protected override async Task<List<FormPermissionDto>?> GetItems() =>
            (await OperationFactory!.New<GetFormPermissionPage>().ExecuteAsync(Input))?.Items;
    }
}