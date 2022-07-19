using Core.Meteor;

namespace Flow.Operations.FormLead.Queries
{
    public class GetFormLeadAsDropDown : DbQueryAsDropDown<FormLead>
    {
        public GetFormLeadAsDropDown() : base("[Flow].[FormLead]")
        {
        }
    }
}
