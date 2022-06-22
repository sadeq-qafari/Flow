using Saanaa.Core.Meteor;

namespace Tenant.Operations.EntityTag.Queries
{
    public class GetEntityTagExcel : SaanaaDbQueryExcel<EntityTag>
    {
        public GetEntityTagExcel() : base("[Tenant].[EntityTag]")
        {
        }
    }
}