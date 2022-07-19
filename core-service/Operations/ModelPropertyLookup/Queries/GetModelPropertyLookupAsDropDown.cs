using Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookupAsDropDown : DbQueryAsDropDown<ModelPropertyLookup>
    {
        public GetModelPropertyLookupAsDropDown() : base("[Core].[ModelPropertyLookup]")
        {
        }
    }
}
