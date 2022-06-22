using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelation.Queries
{
    public class GetEntityRelationByIds : SaanaaDbQueryByIds<EntityRelation>
    {
        public GetEntityRelationByIds() : base("[Core].[EntityRelation]")
        {
        }
    }
}
