using Core.Meteor;

namespace Core.Operations.ModelProperty.Queries
{
    public class GetModelProperty : DbSelectAsync<ModelProperty?>
    {
        public GetModelProperty() : base("[Core].[ModelProperty]")
        {
        }
    }
}
