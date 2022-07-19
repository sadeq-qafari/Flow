using Dapper;

namespace Tenant.Operations.Report.Dtos
{
    public class ReportResultInDto
    {
        public string Query { get; set; }
        public DynamicParameters Params { get; set; }
    }
}
