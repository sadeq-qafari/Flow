using Core.Meteor;

namespace Identity.Operations.Database.Role.Queries
{
    public class GetRoleByIds : DbQueryByIds<Role>
    {
        public GetRoleByIds() : base("[Identity].[Role]")
        {
        }
    }
}
