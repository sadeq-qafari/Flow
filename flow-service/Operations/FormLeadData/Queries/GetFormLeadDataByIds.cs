using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadData.Queries
{
    public class GetFormLeadDataByIds : SaanaaDbQueryByIds<FormLeadData>
    {
        public GetFormLeadDataByIds() : base("[Flow].[FormLeadData]")
        {
        }
    }
}