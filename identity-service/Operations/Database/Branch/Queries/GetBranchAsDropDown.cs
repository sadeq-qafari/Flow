using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Branch.Queries
{
    public class GetBranchAsDropDown : SaanaaDbQueryAsDropDown<Branch>
    {
        public GetBranchAsDropDown() : base("[Identity].[Branch]")
        {
        }
    }
}
