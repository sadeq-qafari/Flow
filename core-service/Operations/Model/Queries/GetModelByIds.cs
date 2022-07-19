using Core.Meteor;

namespace Core.Operations.Model.Queries
{
    public class GetModelByIds : DbQueryByIds<Model>
    {
        public GetModelByIds() : base("[Core].[Model]")
        {
        }
    }
}
