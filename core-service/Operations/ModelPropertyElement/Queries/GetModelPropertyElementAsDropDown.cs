using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Queries
{
    public class GetModelPropertyElementAsDropDown : SaanaaDbQueryAsDropDown<ModelPropertyElement>
    {
        public GetModelPropertyElementAsDropDown() : base("[Core].[ModelPropertyElement]","Name")
        {
        }
    }
}
