using System.Threading.Tasks;
using Core.Operations.ModelPropertyElement.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Commands
{
    public class AddModelPropertyElement : SaanaaDbInsertAsync<AddModelPropertyElementInDto>
    {
        protected override Task PrepareExecutionAsync()
        {
            Input.TenantId = 0;
            return Task.CompletedTask;
        }

        public AddModelPropertyElement() : base("[Core].[ModelPropertyElement]",
            "[Name], [Type], [Attributes]",
            "@Name, @Type, @Attributes")
        {
        }
    }
}

