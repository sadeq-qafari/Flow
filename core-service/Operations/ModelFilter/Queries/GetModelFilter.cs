using Core.Meteor;

namespace Core.Operations.ModelFilter.Queries
{
    public class GetModelFilter : DbSelectAsync<ModelFilter?>
    {
        public GetModelFilter() : base("[Core].[ModelFilter]")
        {
        }
    }
}