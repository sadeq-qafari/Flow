using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Queries
{
    public class GetModelPropertyLookupAsDropDown : SaanaaDbQueryAsDropDown<ModelPropertyLookup>
    {
        public GetModelPropertyLookupAsDropDown() : base("[Core].[ModelPropertyLookup]")
        {
        }
    }
}
