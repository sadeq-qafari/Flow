using Saanaa.Core.Meteor;

namespace Tenant.Operations.Branch.Queries
{
    public class GetBranchAsDropDown : SaanaaDbQueryAsDropDown<Branch>
    {
        public GetBranchAsDropDown() : base("[Identity].[Branch]")
        {
        }
    }
}
