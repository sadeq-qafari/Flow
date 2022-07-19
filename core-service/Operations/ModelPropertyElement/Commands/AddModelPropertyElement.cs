using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelPropertyElement.Dto;

namespace Core.Operations.ModelPropertyElement.Commands
{
    public class AddModelPropertyElement : DbInsertAsync<AddModelPropertyElementInDto>
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

