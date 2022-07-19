using Core.Meteor;

namespace Identity.Operations.Database.Branch.Commands
{
    public class BranchRemove : DbDeleteAsync
    {
        public BranchRemove() : base("[Identity].[Branch]")
        {
        }
    }
}
