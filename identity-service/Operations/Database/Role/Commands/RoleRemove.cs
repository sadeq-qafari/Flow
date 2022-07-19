using Core.Meteor;

namespace Identity.Operations.Database.Role.Commands
{
    public class RoleRemove : DbDeleteAsync
    {
        public RoleRemove() : base("[Identity].[Role]")
        {
        }
    }
}
