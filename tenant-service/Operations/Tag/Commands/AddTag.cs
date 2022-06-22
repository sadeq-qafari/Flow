using Saanaa.Core.Meteor;
using Tenant.Operations.Tag.Dto;

namespace Tenant.Operations.Tag.Commands
{
    public class AddTag : SaanaaDbInsertAsync<AddTagInDto>
    {
        public AddTag() : base("[Tenant].[Tag]",
            @"[Title]",
            @"@Title")
        {
        }
    }
}

