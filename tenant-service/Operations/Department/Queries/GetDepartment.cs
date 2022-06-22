using Saanaa.Core.Meteor;

namespace Tenant.Operations.Department.Queries
{
    public class GetDepartment : SaanaaDbSelectAsync<Department?>
    {
        public GetDepartment() : base("[Tenant].[Department]")
        {
        }
    }
}