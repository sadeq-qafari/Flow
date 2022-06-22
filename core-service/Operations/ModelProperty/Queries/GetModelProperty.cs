using Saanaa.Core.Meteor;

namespace Core.Operations.ModelProperty.Queries
{
    public class GetModelProperty : SaanaaDbSelectAsync<ModelProperty?>
    {
        public GetModelProperty() : base("[Core].[ModelProperty]")
        {
        }
    }
}
