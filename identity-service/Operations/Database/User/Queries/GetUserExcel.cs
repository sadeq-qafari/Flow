using Core.Meteor;

namespace Identity.Operations.Database.User.Queries
{
    public class GetUserExcel : DbQueryExcel<User>
    {
        public GetUserExcel() : base("[Identity].[User]")
        {
        }
    }
}
