using Core.Meteor;
using Core.Operations.Application.Dtos;

namespace Core.Operations.Application.Commands
{
    public class ApplicationUpdate : DbUpdateAsync<ApplicationUpdateInDto>
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