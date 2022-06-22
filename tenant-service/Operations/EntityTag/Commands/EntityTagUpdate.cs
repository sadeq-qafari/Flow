using Saanaa.Core.Meteor;
using Tenant.Operations.EntityTag.Dtos;

namespace Tenant.Operations.EntityTag.Commands
{
    public class EntityTagUpdate : SaanaaDbUpdateAsync<EntityTagUpdateInDto>
    {
        public EntityTagUpdate() : base("[Tenant].[EntityTag]",
            @"[ModelId]=@ModelId,
					[EntityId]=@EntityId,
					[TagId]=@TagId")
        {
        }
    }
}