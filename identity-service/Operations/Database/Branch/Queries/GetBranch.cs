using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Branch.Queries
{
    public class GetBranch : SaanaaDbSelectAsync<Branch?>
    {
        public GetBranch() : base("[Identity].[Branch]")
        {
        }
    }
}
