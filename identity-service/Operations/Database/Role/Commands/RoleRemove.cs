using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Role.Commands
{
    public class RoleRemove : SaanaaDbDeleteAsync
    {
        public RoleRemove() : base("[Identity].[Role]")
        {
        }
    }
}
