using Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Queries
{
    public class GetModelPropertyElement : DbSelectAsync<ModelPropertyElement?>
    {
        public GetModelPropertyElement() : base("[Core].[ModelPropertyElement]")
        {
        }
    }
}
