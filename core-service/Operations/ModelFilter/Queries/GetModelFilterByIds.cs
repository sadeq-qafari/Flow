using Saanaa.Core.Meteor;

namespace Core.Operations.ModelFilter.Queries
{
    public class GetModelFilterByIds : SaanaaDbQueryByIds<ModelFilter>
    {
        public GetModelFilterByIds() : base("[Core].[ModelFilter]")
        {
        }
    }
}