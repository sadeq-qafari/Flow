using System.Threading.Tasks;
using Core.Operations.EntityRelationRule.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelationRule.Commands
{
    public class AddEntityRelationRule : SaanaaDbInsertAsync<AddEntityRelationRuleInDto>
    {
        protected override Task PrepareExecutionAsync()
        {
            Input.TenantId = 0;
            return Task.CompletedTask;
        }

        public AddEntityRelationRule() : base("[Core].[EntityRelationRule]",
            "[ModelIdA], [ModelIdB], [RelationTypeLookup]",
            "@ModelIdA, @ModelIdB, @RelationTypeLookup")
        {
        }
    }
}

