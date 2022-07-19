using Core.Meteor;

namespace Flow.Operations.SqlQuery.Queries
{
    public class GetSqlQuery : DbSelectAsync<SqlQuery?>
    {
        public GetSqlQuery() : base("[Flow].[SqlQuery]")
        {
        }
    }
}