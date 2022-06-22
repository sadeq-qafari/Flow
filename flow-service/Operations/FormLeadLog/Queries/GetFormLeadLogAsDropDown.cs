using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadLog.Queries
{
    public class GetFormLeadLogAsDropDown : SaanaaDbQueryAsDropDown<FormLeadLog>
    {
        public GetFormLeadLogAsDropDown() : base("[Flow].[FormLeadLog]")
        {
        }
    }
}
