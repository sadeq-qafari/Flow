using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.User.Queries
{
    public class GetUserExcel : SaanaaDbQueryExcel<User>
    {
        public GetUserExcel() : base("[Identity].[User]")
        {
        }
    }
}
