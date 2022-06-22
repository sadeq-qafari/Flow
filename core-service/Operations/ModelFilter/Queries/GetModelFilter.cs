using Saanaa.Core.Meteor;

namespace Core.Operations.ModelFilter.Queries
{
    public class GetModelFilter : SaanaaDbSelectAsync<ModelFilter?>
    {
        public GetModelFilter() : base("[Core].[ModelFilter]")
        {
        }
    }
}