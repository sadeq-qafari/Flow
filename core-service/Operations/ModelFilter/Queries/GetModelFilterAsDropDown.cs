using Core.Meteor;

namespace Core.Operations.ModelFilter.Queries
{
    public class GetModelFilterAsDropDown : DbQueryAsDropDown<ModelFilter>
    {
        public GetModelFilterAsDropDown() : base("[Core].[ModelFilter]")
        {
        }
    }
}
