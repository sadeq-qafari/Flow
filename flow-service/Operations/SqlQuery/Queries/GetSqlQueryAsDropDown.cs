using Core.Meteor;

namespace Flow.Operations.SqlQuery.Queries
{
    public class GetSqlQueryAsDropDown : DbQueryAsDropDown<SqlQuery>
    {
        public GetSqlQueryAsDropDown() : base("[Flow].[SqlQuery]")
        {
        }
    }
}
