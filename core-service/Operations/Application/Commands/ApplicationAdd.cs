using Core.Operations.Application.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.Application.Commands
{
    public class ApplicationAdd : SaanaaDbInsertAsync<ApplicationAddInDto>
    {
        public ApplicationAdd() : base("[Core].[Application]",
            @"[Name],
						[Title],
						[Description],
                        [Terms],
                        [GatewayDetailId]",
            @"@Name,
						@Title,
						@Description,
                        @Terms,
                        @GatewayDetailId")
        {
        }
    }
}

