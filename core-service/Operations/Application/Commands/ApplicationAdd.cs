using Core.Meteor;
using Core.Operations.Application.Dtos;

namespace Core.Operations.Application.Commands
{
    public class ApplicationAdd : DbInsertAsync<ApplicationAddInDto>
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

