using Core.Meteor;

namespace Identity.Operations.Database.User.Queries
{
    public class GetUserByIds : DbQueryByIds<User>
    {
        public GetUserByIds() : base("[Identity].[User]")
        {
        }
    }
}
