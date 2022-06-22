using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Queries
{
    public class GetModelPropertyElement : SaanaaDbSelectAsync<ModelPropertyElement?>
    {
        public GetModelPropertyElement() : base("[Core].[ModelPropertyElement]")
        {
        }
    }
}
