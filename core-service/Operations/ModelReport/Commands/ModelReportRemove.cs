using Core.Meteor;

namespace Core.Operations.ModelReport.Commands
{
    public class ModelReportRemove : DbDeleteAsync
    {
        public ModelReportRemove() : base("[Core].[ModelReport]")
        {
        }
    }
}