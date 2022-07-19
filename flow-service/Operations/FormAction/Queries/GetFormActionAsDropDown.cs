using Core.Meteor;

namespace Flow.Operations.FormAction.Queries
{
    public class GetFormActionAsDropDown : DbQueryAsDropDown<FormAction>
    {
        public GetFormActionAsDropDown() : base("[Flow].[FormAction]")
        {
        }
    }
}
