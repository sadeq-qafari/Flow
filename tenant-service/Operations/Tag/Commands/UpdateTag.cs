using Core.Meteor;
using Tenant.Operations.Tag.Dto;

namespace Tenant.Operations.Tag.Commands
{
    public class UpdateTag : DbUpdateAsync<UpdateTagInDto>
    {
        public UpdateTag() : base("[Tenant].[Tag]",
            @"[Title]=@Title")
        {
        }
    }
}