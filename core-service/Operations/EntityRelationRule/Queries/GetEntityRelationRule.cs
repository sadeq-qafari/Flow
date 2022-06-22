using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelationRule.Queries
{
    public class GetEntityRelationRule : SaanaaDbSelectAsync<EntityRelationRule?>
    {
        public GetEntityRelationRule() : base("[Core].[EntityRelationRule]")
        {
        }
    }
}
