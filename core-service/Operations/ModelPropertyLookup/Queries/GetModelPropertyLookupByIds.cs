using Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookupByIds : DbQueryByIds<ModelPropertyLookup>
    {
        public GetModelPropertyLookupByIds() : base("[Core].[ModelPropertyLookup]")
        {
        }
    }
}
