using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelationRule.Commands
{
    public class RemoveEntityRelationRule : SaanaaDbDeleteAsync
    {
        public RemoveEntityRelationRule() : base("[Core].[EntityRelationRule]")
        {
        }
    }
}
