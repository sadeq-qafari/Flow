using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookup : SaanaaDbSelectAsync<ModelPropertyLookup?>
    {
        public GetModelPropertyLookup() : base("[Core].[ModelPropertyLookup]")
        {
        }
    }
}
