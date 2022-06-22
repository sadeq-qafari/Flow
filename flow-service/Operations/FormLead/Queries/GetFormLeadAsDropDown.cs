using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLead.Queries
{
    public class GetFormLeadAsDropDown : SaanaaDbQueryAsDropDown<FormLead>
    {
        public GetFormLeadAsDropDown() : base("[Flow].[FormLead]")
        {
        }
    }
}
