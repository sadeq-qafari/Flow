using Core.Meteor;

namespace Flow.Operations.FormProperty.Queries
{
    public class GetFormPropertyAsDropDown : DbQueryAsDropDown<FormProperty>
    {
        public GetFormPropertyAsDropDown() : base("[Flow].[FormProperty]")
        {
        }
    }
}
