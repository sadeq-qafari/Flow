using Saanaa.Core.Meteor;

namespace Tenant.Operations.Department.Queries
{
    public class GetDepartmentExcel : SaanaaDbQueryExcel<Department>
    {
        public GetDepartmentExcel() : base("[Tenant].[Department]")
        {
        }
    }
}