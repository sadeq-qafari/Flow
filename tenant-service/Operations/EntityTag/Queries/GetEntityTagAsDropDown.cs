using Saanaa.Core.Meteor;

namespace Tenant.Operations.EntityTag.Queries
{
    public class GetEntityTagAsDropDown : SaanaaDbQueryAsDropDown<EntityTag>
    {
        public GetEntityTagAsDropDown() : base("[Tenant].[EntityTag]")
        {
        }
    }
}
