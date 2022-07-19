using Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Queries
{
    public class GetModelPropertyElementByIds : DbQueryByIds<ModelPropertyElement>
    {
        public GetModelPropertyElementByIds() : base("[Core].[ModelPropertyElement]")
        {
        }
    }
}
