using Core.Meteor;

namespace Flow.Operations.FormAction.Commands
{
    public class FormActionRemove : DbDeleteAsync
    {
        public FormActionRemove() : base("[Flow].[FormAction]")
        {
        }
    }
}