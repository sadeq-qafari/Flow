using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Queries
{
    public class GetModelPropertyElementByIds : SaanaaDbQueryByIds<ModelPropertyElement>
    {
        public GetModelPropertyElementByIds() : base("[Core].[ModelPropertyElement]")
        {
        }
    }
}
