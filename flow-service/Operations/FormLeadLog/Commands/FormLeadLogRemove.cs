using Core.Meteor;

namespace Flow.Operations.FormLeadLog.Commands
{
    public class FormLeadLogRemove : DbDeleteAsync
    {
        public FormLeadLogRemove() : base("[Flow].[FormLeadLog]")
        {
        }
    }
}