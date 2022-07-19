using Core.Meteor;

namespace Flow.Operations.Form.Commands
{
    public class FormRemove : DbDeleteAsync
    {
        public FormRemove() : base("[Flow].[Form]")
        {
        }
    }
}