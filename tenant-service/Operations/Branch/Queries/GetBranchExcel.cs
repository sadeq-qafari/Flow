using Core.Meteor;

namespace Tenant.Operations.Branch.Queries
{
    public class GetBranchExcel : DbQueryExcel<Branch>
    {
        public GetBranchExcel() : base("[Identity].[Branch]")
        {
        }
    }
}
