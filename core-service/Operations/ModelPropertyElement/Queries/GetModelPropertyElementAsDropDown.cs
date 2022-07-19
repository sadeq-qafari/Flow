using Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Queries
{
    public class GetModelPropertyElementAsDropDown : DbQueryAsDropDown<ModelPropertyElement>
    {
        public GetModelPropertyElementAsDropDown() : base("[Core].[ModelPropertyElement]","Name")
        {
        }
    }
}
