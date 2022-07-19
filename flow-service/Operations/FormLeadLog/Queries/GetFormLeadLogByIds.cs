using Core.Meteor;

namespace Flow.Operations.FormLeadLog.Queries
{
    public class GetFormLeadLogByIds : DbQueryByIds<FormLeadLog>
    {
        public GetFormLeadLogByIds() : base("[Flow].[FormLeadLog]")
        {
        }
    }
}