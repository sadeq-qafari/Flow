using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Flow.Operations.SqlQuery.Dtos;
using Meteor.Operation;

namespace Flow.Operations.SqlQuery.Queries
{
    public class GetSqlQueryExcel : DbQueryExcel<SqlQueryDto>
    {
        public GetSqlQueryExcel() : base("[Flow].[SqlQuery]")
        {
        }
        
        protected override async Task<List<SqlQueryDto>?> GetItems() =>
            (await OperationFactory!.New<GetSqlQueryPage>().ExecuteAsync(Input))?.Items;
    }
}