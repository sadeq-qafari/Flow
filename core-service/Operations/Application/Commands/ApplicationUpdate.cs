using Core.Operations.Application.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.Application.Commands
{
    public class ApplicationUpdate : SaanaaDbUpdateAsync<ApplicationUpdateInDto>
    {
        public ApplicationUpdate() : base("[Core].[Application]",
            @"[Name]=@Name,
					[Title]=@Title,
					[Description]=@Description,
                    [Terms]=@Terms,
                    [GatewayDetailId]=@GatewayDetailId")
        {
        }
    }
}