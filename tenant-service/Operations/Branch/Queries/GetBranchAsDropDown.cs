using Core.Meteor;

namespace Tenant.Operations.Branch.Queries
{
    public class GetBranchAsDropDown : DbQueryAsDropDown<Branch>
    {
        public GetBranchAsDropDown() : base("[Identity].[Branch]")
        {
        }
    }
}
