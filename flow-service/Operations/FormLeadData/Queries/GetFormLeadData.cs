using Core.Meteor;

namespace Flow.Operations.FormLeadData.Queries
{
    public class GetFormLeadData : DbSelectAsync<FormLeadData?>
    {
        public GetFormLeadData() : base("[Flow].[FormLeadData]")
        {
        }
    }
}