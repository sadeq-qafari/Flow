using Saanaa.Core.Meteor;

namespace Tenant.Operations.Department.Queries
{
    public class GetDepartmentByIds : SaanaaDbQueryByIds<Department>
    {
        public GetDepartmentByIds() : base("[Tenant].[Department]")
        {
        }
    }
}