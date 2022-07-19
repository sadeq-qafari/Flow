using Core.Meteor;

namespace Tenant.Operations.Branch.Queries
{
    public class GetBranch : DbSelectAsync<Branch?>
    {
        public GetBranch() : base("[Identity].[Branch]")
        {
        }
    }
}
