using Core.Meteor;

namespace Flow.Operations.FormLead.Queries
{
    public class GetFormLeadByIds : DbQueryByIds<FormLead>
    {
        public GetFormLeadByIds() : base("[Flow].[FormLead]")
        {
        }
    }
}