using Saanaa.Core.Meteor;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReportAsDropDown : SaanaaDbQueryAsDropDown<ModelReport>
    {
        public GetModelReportAsDropDown() : base("[Core].[ModelReport]")
        {
        }
    }
}
