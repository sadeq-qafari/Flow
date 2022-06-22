using Saanaa.Core.Meteor;

namespace Core.Operations.ModelReport.Commands
{
    public class ModelReportRemove : SaanaaDbDeleteAsync
    {
        public ModelReportRemove() : base("[Core].[ModelReport]")
        {
        }
    }
}