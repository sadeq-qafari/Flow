using System.Threading.Tasks;
using Core.Operations.ModelPropertyLookup.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Commands
{
    public class AddModelPropertyLookup : SaanaaDbInsertAsync<AddModelPropertyLookupInDto>
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

