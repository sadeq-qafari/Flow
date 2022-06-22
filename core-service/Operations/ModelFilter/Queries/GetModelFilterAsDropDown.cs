using Saanaa.Core.Meteor;

namespace Core.Operations.ModelFilter.Queries
{
    public class GetModelFilterAsDropDown : SaanaaDbQueryAsDropDown<ModelFilter>
    {
        public GetModelFilterAsDropDown() : base("[Core].[ModelFilter]")
        {
        }
    }
}
