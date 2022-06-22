using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadLog.Queries
{
    public class GetFormLeadLogByIds : SaanaaDbQueryByIds<FormLeadLog>
    {
        public GetFormLeadLogByIds() : base("[Flow].[FormLeadLog]")
        {
        }
    }
}