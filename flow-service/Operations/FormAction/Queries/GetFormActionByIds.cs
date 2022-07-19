using Core.Meteor;

namespace Flow.Operations.FormAction.Queries
{
    public class GetFormActionByIds : DbQueryByIds<FormAction>
    {
        public GetFormActionByIds() : base("[Flow].[FormAction]")
        {
        }
    }
}