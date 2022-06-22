using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.User.Queries
{
    public class GetUserByIds : SaanaaDbQueryByIds<User>
    {
        public GetUserByIds() : base("[Identity].[User]")
        {
        }
    }
}
