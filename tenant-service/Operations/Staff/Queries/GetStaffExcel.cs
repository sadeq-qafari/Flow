using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Tenant.Operations.Staff.Dtos;

namespace Tenant.Operations.Staff.Queries
{
    public class GetStaffExcel : DbQueryExcel<StaffDto>
    {
        public GetStaffExcel() : base("[Tenant].[v_Staff]")
        {
        }
        
        protected override async Task<List<StaffDto>?> GetItems() =>
            (await OperationFactory!.New<GetStaffPage>().ExecuteAsync(Input))?.Items;
    }
}