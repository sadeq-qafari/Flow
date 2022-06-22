using Saanaa.Core.Meteor;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReport : SaanaaDbSelectAsync<ModelReport?>
    {
        public GetModelReport() : base("[Core].[ModelReport]")
        {
        }
    }
}