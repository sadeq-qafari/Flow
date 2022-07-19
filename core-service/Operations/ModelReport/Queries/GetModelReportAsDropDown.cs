using Core.Meteor;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReportAsDropDown : DbQueryAsDropDown<ModelReport>
    {
        public GetModelReportAsDropDown() : base("[Core].[ModelReport]")
        {
        }
    }
}
