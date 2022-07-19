using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ServiceConfig.Dto;

namespace Core.Operations.ServiceConfig.Commands
{
    public class AddServiceConfig : DbInsertAsync<AddServiceConfigInDto>
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

