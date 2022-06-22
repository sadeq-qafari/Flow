using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelation.Queries
{
    public class GetEntityRelationAsDropDown : SaanaaDbQueryAsDropDown<EntityRelation>
    {
        public GetEntityRelationAsDropDown() : base("[Core].[EntityRelation]")
        {
        }
    }
}
