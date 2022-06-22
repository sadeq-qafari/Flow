using Saanaa.Core.Meteor;

namespace Tenant.Operations.Department.Queries
{
    public class GetDepartmentAsDropDown : SaanaaDbQueryAsDropDown<Department>
    {
        public GetDepartmentAsDropDown() : base("[Tenant].[Department]")
        {
        }
    }
}
