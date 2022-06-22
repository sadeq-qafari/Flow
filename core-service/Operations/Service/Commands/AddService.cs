using System.Threading.Tasks;
using Core.Operations.Service.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Service.Commands
{
    public class AddService : SaanaaDbInsertAsync<AddServiceInDto>
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

