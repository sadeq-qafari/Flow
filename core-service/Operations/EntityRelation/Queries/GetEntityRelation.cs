using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelation.Queries
{
    public class GetEntityRelation : SaanaaDbSelectAsync<EntityRelation?>
    {
        public GetEntityRelation() : base("[Core].[EntityRelation]")
        {
        }
    }
}
