using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Flow.Operations.FormProperty.Queries
{
    public class GetFormProperties : DbOperationAsync<int, List<FormProperty>>
    {
        protected override async Task ExecutionAsync()
        {
            Output = (await NewSql(sql => sql
                        .Select("[Flow].[FormProperty]")
                        .Where("FormId=@FormId AND IsDeleted=0"),
                    new { FormId = Input })
                .QueryAsync<FormProperty>()).ToList();
        }
    }
}
