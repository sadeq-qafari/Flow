using Core.Meteor;

namespace Flow.Operations.FormLead.Commands
{
    public class FormLeadRemove : DbDeleteAsync
    {
        public FormLeadRemove() : base("[Flow].[FormLead]")
        {
        }
    }
}