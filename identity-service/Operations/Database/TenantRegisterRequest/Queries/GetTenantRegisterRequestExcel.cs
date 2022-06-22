using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantRegisterRequest.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Queries
{
    public class GetTenantRegisterRequestExcel : SaanaaDbQueryExcel<TenantRegisterRequestDto>
    {
        public GetTenantRegisterRequestExcel() : base("[Identity].[TenantRegisterRequest]")
        {
        }
        
        protected override async Task<List<TenantRegisterRequestDto>?> GetItems() =>
            (await OperationFactory!.New<GetTenantRegisterRequestPage>().ExecuteAsync(Input))?.Items;
    }
}