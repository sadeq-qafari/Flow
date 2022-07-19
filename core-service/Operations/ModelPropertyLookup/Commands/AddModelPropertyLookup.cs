using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelPropertyLookup.Dto;

namespace Core.Operations.ModelPropertyLookup.Commands
{
    public class AddModelPropertyLookup : DbInsertAsync<AddModelPropertyLookupInDto>
    {
        protected override Task PrepareExecutionAsync()
        {
            Input.TenantId = 0;
            return Task.CompletedTask;
        }

        public AddModelPropertyLookup() : base("[Core].[ModelPropertyLookup]",
            "[ModelPropertyId], [Title], [Value]",
            "@ModelPropertyId, @Title, @Value")
        {
        }
    }
}

