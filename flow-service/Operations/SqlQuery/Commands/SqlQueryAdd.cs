using Core.Meteor;
using Flow.Operations.SqlQuery.Dtos;

namespace Flow.Operations.SqlQuery.Commands
{
    public class SqlQueryAdd : DbInsertAsync<SqlQueryAddInDto>
    {
        public SqlQueryAdd() : base("[Flow].[SqlQuery]",
            @"[Title],
						[Query],
						[ResultType]",
            @"@Title,
						@Query,
						@ResultType")
        {
        }
    }
}

