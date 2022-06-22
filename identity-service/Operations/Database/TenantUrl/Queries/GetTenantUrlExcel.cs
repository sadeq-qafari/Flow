using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantUrl.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantUrl.Queries
{
    public class GetTenantUrlExcel : SaanaaDbQueryExcel<TenantUrlDto>
    {
        public GetTenantUrlExcel() : base("[Identity].[TenantUrl]")
        {
        }

        protected override async Task<List<TenantUrlDto>?> GetItems() =>
            (await OperationFactory!.New<GetTenantUrlPage>().ExecuteAsync(Input))?.Items;
    }
}
