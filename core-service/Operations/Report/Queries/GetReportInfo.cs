using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Core.Operations.Report.Queries
{
    public class GetReportInfo : DbOperationAsync<string, Report>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.Select("[Core].[Report]")
                    .Where("Name=@Name AND IsActive=1"), new {Name = Input})
                .QueryFirstOrDefaultAsync<Report>();
        }
    }
}
