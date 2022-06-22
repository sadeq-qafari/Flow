using Saanaa.Core.Meteor;

namespace Tenant.Operations.Branch.Commands
{
    public class BranchRemove : SaanaaDbDeleteAsync
    {
        public BranchRemove() : base("[Identity].[Branch]")
        {
        }
    }
}
