using Core.Meteor;

namespace Flow.Operations.SqlQuery.Queries
{
    public class GetSqlQueryByIds : DbQueryByIds<SqlQuery>
    {
        public GetSqlQueryByIds() : base("[Flow].[SqlQuery]")
        {
        }
    }
}