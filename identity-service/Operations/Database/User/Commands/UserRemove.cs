using Core.Meteor;

namespace Identity.Operations.Database.User.Commands
{
    public class UserRemove : DbDeleteAsync
    {
        public UserRemove() : base("[Identity].[User]")
        {
        }
    }
}
