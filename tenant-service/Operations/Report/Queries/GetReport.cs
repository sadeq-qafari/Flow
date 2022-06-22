using Saanaa.Core.Meteor;

namespace Tenant.Operations.Report.Queries
{
    public class GetReport : SaanaaDbSelectAsync<Report?>
    {
        public GetReport() : base("[Tenant].[Report]")
        {
        }
    }
}