using Core.Meteor;

namespace Core.Operations.ModelProperty.Queries
{
    public class GetModelPropertyByIds : DbQueryByIds<ModelProperty>
    {
        public GetModelPropertyByIds() : base("[Core].[ModelProperty]")
        {
        }
    }
}
