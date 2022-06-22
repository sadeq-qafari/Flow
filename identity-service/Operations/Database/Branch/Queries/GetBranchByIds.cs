using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Branch.Queries
{
    public class GetBranchByIds : SaanaaDbQueryByIds<Branch>
    {
        public GetBranchByIds() : base("[Identity].[Branch]")
        {
        }
    }
}
