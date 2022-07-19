using Core.Meteor;
using Flow.Operations.SqlQuery.Dtos;

namespace Flow.Operations.SqlQuery.Commands
{
    public class SqlQueryUpdate : DbUpdateAsync<SqlQueryUpdateInDto>
    {
        public SqlQueryUpdate() : base("[Flow].[SqlQuery]",
            @"[Title]=@Title,
					[Query]=@Query,
					[ResultType]=@ResultType")
        {
        }
    }
}