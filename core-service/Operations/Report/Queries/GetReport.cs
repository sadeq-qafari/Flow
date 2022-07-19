using Core.Meteor;

namespace Core.Operations.Report.Queries
{
    public class GetReport : DbSelectAsync<Report?>
    {
        public GetReport() : base("[Core].[Report]")
        {
        }
    }
}