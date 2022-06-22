using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Branch.Queries
{
    public class GetBranchExcel : SaanaaDbQueryExcel<Branch>
    {
        public GetBranchExcel() : base("[Identity].[Branch]")
        {
        }
    }
}
