using Core.Meteor;

namespace Tenant.Operations.Branch.Queries
{
    public class GetBranchByIds : DbQueryByIds<Branch>
    {
        public GetBranchByIds() : base("[Identity].[Branch]")
        {
        }
    }
}
