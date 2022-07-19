using Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookup : DbSelectAsync<ModelPropertyLookup?>
    {
        public GetModelPropertyLookup() : base("[Core].[ModelPropertyLookup]")
        {
        }
    }
}
