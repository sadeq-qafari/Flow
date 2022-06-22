using Identity.Operations.Database.Branch.Dtos;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Branch.Commands
{
    public class BranchAdd : SaanaaDbInsertAsync<BranchAddInDto>
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

