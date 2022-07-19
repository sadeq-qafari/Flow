using Core.Meteor;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReportByIds : DbQueryByIds<ModelReport>
    {
        public GetModelReportByIds() : base("[Core].[ModelReport]")
        {
        }
    }
}