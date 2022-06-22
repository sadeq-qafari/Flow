using System.Threading.Tasks;
using Core.Operations.ServiceConfig.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ServiceConfig.Commands
{
    public class AddServiceConfig : SaanaaDbInsertAsync<AddServiceConfigInDto>
    {
        protected override Task PrepareExecutionAsync()
        {
            Input.TenantId = 0;
            return Task.CompletedTask;
        }

        public AddServiceConfig() : base("[Core].[ServiceConfig]",
            "[ServiceName], [Key], [Value]",
            "@ServiceName, @Key, @Value")
        {
        }
    }
}

