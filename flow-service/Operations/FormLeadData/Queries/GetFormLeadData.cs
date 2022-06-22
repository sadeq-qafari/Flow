using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadData.Queries
{
    public class GetFormLeadData : SaanaaDbSelectAsync<FormLeadData?>
    {
        public GetFormLeadData() : base("[Flow].[FormLeadData]")
        {
        }
    }
}