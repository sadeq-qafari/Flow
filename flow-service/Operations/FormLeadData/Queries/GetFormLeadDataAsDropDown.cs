using Core.Meteor;

namespace Flow.Operations.FormLeadData.Queries
{
    public class GetFormLeadDataAsDropDown : DbQueryAsDropDown<FormLeadData>
    {
        public GetFormLeadDataAsDropDown() : base("[Flow].[FormLeadData]")
        {
        }
    }
}
