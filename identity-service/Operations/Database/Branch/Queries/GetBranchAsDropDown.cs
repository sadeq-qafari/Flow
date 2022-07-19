using Core.Meteor;

namespace Identity.Operations.Database.Branch.Queries
{
    public class GetBranchAsDropDown : DbQueryAsDropDown<Branch>
    {
        public GetBranchAsDropDown() : base("[Identity].[Branch]")
        {
        }
    }
}
