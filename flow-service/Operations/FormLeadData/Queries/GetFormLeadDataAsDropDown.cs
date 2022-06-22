using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadData.Queries
{
    public class GetFormLeadDataAsDropDown : SaanaaDbQueryAsDropDown<FormLeadData>
    {
        public GetFormLeadDataAsDropDown() : base("[Flow].[FormLeadData]")
        {
        }
    }
}
