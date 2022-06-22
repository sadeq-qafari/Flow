using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Role.Queries
{
    public class GetRoleByIds : SaanaaDbQueryByIds<Role>
    {
        public GetRoleByIds() : base("[Identity].[Role]")
        {
        }
    }
}
