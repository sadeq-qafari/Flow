using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Core.Operations.Application.Queries
{
    public class GetApplicationTerms : DbOperationAsync<int?, string?>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.Select("[Core].[Application]", "Terms").Where("Id=@Id"),
                new { Id = Input }).ExecuteScalarAsync<string?>();
        }
    }
}