using Saanaa.Core.Meteor;

namespace Core.Operations.ModelProperty.Queries
{
    public class GetModelPropertyByIds : SaanaaDbQueryByIds<ModelProperty>
    {
        public GetModelPropertyByIds() : base("[Core].[ModelProperty]")
        {
        }
    }
}
