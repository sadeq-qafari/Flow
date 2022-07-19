using Core.Meteor;

namespace Identity.Operations.Database.Branch.Queries
{
    public class GetBranchByIds : DbQueryByIds<Branch>
    {
        public GetBranchByIds() : base("[Identity].[Branch]")
        {
        }
    }
}
