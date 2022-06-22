using Saanaa.Core.Meteor;

namespace Tenant.Operations.Branch.Queries
{
    public class GetBranchByIds : SaanaaDbQueryByIds<Branch>
    {
        public GetBranchByIds() : base("[Identity].[Branch]")
        {
        }
    }
}
