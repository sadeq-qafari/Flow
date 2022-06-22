using Identity.Operations.Database.Branch.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Branch.Commands
{
    public class BranchUpdate : SaanaaDbUpdateAsync<BranchUpdateInDto>
    {
        public BranchUpdate() : base("[Identity].[Branch]",
            @"[ParentId]=@ParentId,
					[Title]=@Title")
        {
        }
    }
}
