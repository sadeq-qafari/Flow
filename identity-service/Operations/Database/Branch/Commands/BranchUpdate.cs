using Identity.Operations.Database.Branch.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.Branch.Commands
{
    public class BranchUpdate : DbUpdateAsync<BranchUpdateInDto>
    {
        public BranchUpdate() : base("[Identity].[Branch]",
            @"[ParentId]=@ParentId,
					[Title]=@Title")
        {
        }
    }
}
