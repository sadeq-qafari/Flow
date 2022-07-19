using Core.Meteor;
using Tenant.Operations.EntityTag.Dtos;

namespace Tenant.Operations.EntityTag.Commands
{
    public class EntityTagAdd : DbInsertAsync<EntityTagAddInDto>
    {
        public EntityTagAdd() : base("[Tenant].[EntityTag]",
            @"[ModelId],
						[EntityId],
						[TagId]",
            @"@ModelId,
						@EntityId,
						@TagId")
        {
        }
    }
}

