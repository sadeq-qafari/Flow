using Saanaa.Core.Meteor;

namespace Tenant.Operations.Role.Queries
{
    public class GetRoleExcel : SaanaaDbQueryExcel<Role>
    {
        public GetRoleExcel() : base("[Tenant].[Role]")
        {
        }
    }
}