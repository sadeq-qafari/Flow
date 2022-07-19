using Core.Meteor;

namespace Core.Operations.ModelFilter.Queries
{
    public class GetModelFilterByIds : DbQueryByIds<ModelFilter>
    {
        public GetModelFilterByIds() : base("[Core].[ModelFilter]")
        {
        }
    }
}