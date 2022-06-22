using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadLog.Queries
{
    public class GetFormLeadLog : SaanaaDbSelectAsync<FormLeadLog?>
    {
        public GetFormLeadLog() : base("[Flow].[FormLeadLog]")
        {
        }
    }
}