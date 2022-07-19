using Core.Meteor;
using Flow.Operations.SqlQuery.Dtos;

namespace Flow.Operations.SqlQuery.Queries
{
    public class GetSqlQueryPage : DbQueryPage<SqlQueryDto>
    {
        public GetSqlQueryPage() : base("[Flow].[SqlQuery]")
        {
        }
        
    }
}