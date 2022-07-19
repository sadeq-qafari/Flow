using Identity.Operations.Database.Branch.Dtos;
using Core.Meteor;

namespace Identity.Operations.Database.Branch.Commands
{
    public class BranchAdd : DbInsertAsync<BranchAddInDto>
    {
        public BranchAdd() : base("[Identity].[Branch]",
            @"[ParentId],
						[Title]",
            @"@ParentId,
						@Title")
        {
        }
    }
}

