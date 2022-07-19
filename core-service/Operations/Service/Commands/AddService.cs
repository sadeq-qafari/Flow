using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.Service.Dto;

namespace Core.Operations.Service.Commands
{
    public class AddService : DbInsertAsync<AddServiceInDto>
    {
        protected override Task PrepareExecutionAsync()
        {
            Input.TenantId = 0;
            return Task.CompletedTask;
        }

        public AddService() : base("[Core].[Service]",
            "[Name], [Title]",
            "@Name, @Title")
        {
        }
    }
}

