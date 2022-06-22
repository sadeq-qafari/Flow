using Saanaa.Core.Meteor;

namespace Tenant.Operations.Branch.Queries
{
    public class GetBranch : SaanaaDbSelectAsync<Branch?>
    {
        public GetBranch() : base("[Identity].[Branch]")
        {
        }
    }
}
