using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Branch.Commands
{
    public class BranchRemove : SaanaaDbDeleteAsync
    {
        public BranchRemove() : base("[Identity].[Branch]")
        {
        }
    }
}
