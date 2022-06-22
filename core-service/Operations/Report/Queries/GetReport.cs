using Saanaa.Core.Meteor;

namespace Core.Operations.Report.Queries
{
    public class GetReport : SaanaaDbSelectAsync<Report?>
    {
        public GetReport() : base("[Core].[Report]")
        {
        }
    }
}