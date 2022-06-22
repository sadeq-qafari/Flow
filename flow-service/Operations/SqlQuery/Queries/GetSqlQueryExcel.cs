using System.Collections.Generic;
using System.Threading.Tasks;
using Flow.Operations.SqlQuery.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.SqlQuery.Queries
{
    public class GetSqlQueryExcel : SaanaaDbQueryExcel<SqlQueryDto>
    {
        public GetSqlQueryExcel() : base("[Flow].[SqlQuery]")
        {
        }
        
        protected override async Task<List<SqlQueryDto>?> GetItems() =>
            (await OperationFactory!.New<GetSqlQueryPage>().ExecuteAsync(Input))?.Items;
    }
}