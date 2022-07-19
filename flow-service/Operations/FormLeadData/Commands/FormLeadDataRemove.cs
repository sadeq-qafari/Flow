using Core.Meteor;

namespace Flow.Operations.FormLeadData.Commands
{
    public class FormLeadDataRemove : DbDeleteAsync
    {
        public FormLeadDataRemove() : base("[Flow].[FormLeadData]")
        {
        }
    }
}