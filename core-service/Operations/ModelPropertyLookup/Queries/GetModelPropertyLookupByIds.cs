using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookupByIds : SaanaaDbQueryByIds<ModelPropertyLookup>
    {
        public GetModelPropertyLookupByIds() : base("[Core].[ModelPropertyLookup]")
        {
        }
    }
}
