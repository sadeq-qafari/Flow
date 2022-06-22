using Flow.Operations.SqlQuery.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.SqlQuery.Commands
{
    public class SqlQueryUpdate : SaanaaDbUpdateAsync<SqlQueryUpdateInDto>
    {
        public SqlQueryUpdate() : base("[Flow].[SqlQuery]",
            @"[Title]=@Title,
					[Query]=@Query,
					[ResultType]=@ResultType")
        {
        }
    }
}