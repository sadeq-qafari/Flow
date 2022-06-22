using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Role.Queries
{
    public class GetRoleExcel : SaanaaDbQueryExcel<Role>
    {
        public GetRoleExcel() : base("[Identity].[Role]")
        {
        }
    }
}
