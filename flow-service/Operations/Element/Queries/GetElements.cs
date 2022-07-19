using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.Element.Dtos;
using Meteor.Operation.Db;

namespace Flow.Operations.Element.Queries
{
    public class GetElements : DbOutOperationAsync<IEnumerable<ElementsDto>?>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql
                    .Select("[Flow].[Element]", 
                        @"Element.Id,
                                     Element.AcceptableTypes,
                                     Element.ComponentName,
                                     Element.Config,
                                     Element.Icon,
                                     Element.Name,
                                     Element.Title"
                        )
                    .Where("IsDeleted = 0"))
                .QueryAsync<ElementsDto>();
        }
    }
}