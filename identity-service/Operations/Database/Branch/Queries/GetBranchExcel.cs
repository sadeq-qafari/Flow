using Core.Meteor;

namespace Identity.Operations.Database.Branch.Queries
{
    public class GetBranchExcel : DbQueryExcel<Branch>
    {
        public GetBranchExcel() : base("[Identity].[Branch]")
        {
        }
    }
}
