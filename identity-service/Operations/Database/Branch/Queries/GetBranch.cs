using Core.Meteor;

namespace Identity.Operations.Database.Branch.Queries
{
    public class GetBranch : DbSelectAsync<Branch?>
    {
        public GetBranch() : base("[Identity].[Branch]")
        {
        }
    }
}
