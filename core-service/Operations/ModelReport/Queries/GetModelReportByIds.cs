using Saanaa.Core.Meteor;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReportByIds : SaanaaDbQueryByIds<ModelReport>
    {
        public GetModelReportByIds() : base("[Core].[ModelReport]")
        {
        }
    }
}