using Core.Meteor;

namespace Tenant.Operations.Branch.Commands
{
    public class BranchRemove : DbDeleteAsync
    {
        public BranchRemove() : base("[Identity].[Branch]")
        {
        }
    }
}
