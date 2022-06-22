using Core.Operations.ServiceConfig.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ServiceConfig.Commands
{
    public class UpdateServiceConfig : SaanaaDbUpdateAsync<UpdateServiceConfigInDto>
    {
        public UpdateServiceConfig() : base("[Core].[ServiceConfig]",
            "[ServiceName]=@ServiceName, [Key]=@Key, [Value]=@Value")
        {
        }
    }
}
