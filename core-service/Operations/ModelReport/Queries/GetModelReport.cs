using Core.Meteor;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReport : DbSelectAsync<ModelReport?>
    {
        public GetModelReport() : base("[Core].[ModelReport]")
        {
        }
    }
}