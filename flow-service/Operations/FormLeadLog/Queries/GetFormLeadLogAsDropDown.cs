using Core.Meteor;

namespace Flow.Operations.FormLeadLog.Queries
{
    public class GetFormLeadLogAsDropDown : DbQueryAsDropDown<FormLeadLog>
    {
        public GetFormLeadLogAsDropDown() : base("[Flow].[FormLeadLog]")
        {
        }
    }
}
