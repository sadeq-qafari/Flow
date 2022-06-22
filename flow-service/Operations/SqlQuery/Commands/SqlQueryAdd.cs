using Flow.Operations.SqlQuery.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.SqlQuery.Commands
{
    public class SqlQueryAdd : SaanaaDbInsertAsync<SqlQueryAddInDto>
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

