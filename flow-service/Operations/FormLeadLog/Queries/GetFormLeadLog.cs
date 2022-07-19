using Core.Meteor;

namespace Flow.Operations.FormLeadLog.Queries
{
    public class GetFormLeadLog : DbSelectAsync<FormLeadLog?>
    {
        public GetFormLeadLog() : base("[Flow].[FormLeadLog]")
        {
        }
    }
}