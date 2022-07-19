using Core.Meteor;

namespace Flow.Operations.FormLead.Queries
{
    public class GetFormLead : DbSelectAsync<FormLead?>
    {
        public GetFormLead() : base("[Flow].[FormLead]")
        {
        }
    }
}