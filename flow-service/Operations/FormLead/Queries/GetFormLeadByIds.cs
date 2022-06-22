using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLead.Queries
{
    public class GetFormLeadByIds : SaanaaDbQueryByIds<FormLead>
    {
        public GetFormLeadByIds() : base("[Flow].[FormLead]")
        {
        }
    }
}