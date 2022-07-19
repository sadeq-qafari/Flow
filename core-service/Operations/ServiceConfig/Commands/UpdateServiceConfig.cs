using Core.Meteor;
using Core.Operations.ServiceConfig.Dto;

namespace Core.Operations.ServiceConfig.Commands
{
    public class UpdateServiceConfig : DbUpdateAsync<UpdateServiceConfigInDto>
    {
        public UpdateServiceConfig() : base("[Core].[ServiceConfig]",
            "[ServiceName]=@ServiceName, [Key]=@Key, [Value]=@Value")
        {
        }
    }
}
