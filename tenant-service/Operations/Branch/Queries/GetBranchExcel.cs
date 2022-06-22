using Saanaa.Core.Meteor;

namespace Tenant.Operations.Branch.Queries
{
    public class GetBranchExcel : SaanaaDbQueryExcel<Branch>
    {
        public GetBranchExcel() : base("[Identity].[Branch]")
        {
        }
    }
}
