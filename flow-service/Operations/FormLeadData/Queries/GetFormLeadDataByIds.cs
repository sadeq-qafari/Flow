using Core.Meteor;

namespace Flow.Operations.FormLeadData.Queries
{
    public class GetFormLeadDataByIds : DbQueryByIds<FormLeadData>
    {
        public GetFormLeadDataByIds() : base("[Flow].[FormLeadData]")
        {
        }
    }
}