using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.User.Commands
{
    public class UserRemove : SaanaaDbDeleteAsync
    {
        public UserRemove() : base("[Identity].[User]")
        {
        }
    }
}
