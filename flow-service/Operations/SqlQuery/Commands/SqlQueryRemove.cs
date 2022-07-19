using Core.Meteor;

namespace Flow.Operations.SqlQuery.Commands
{
    public class SqlQueryRemove : DbDeleteAsync
    {
        public SqlQueryRemove() : base("[Flow].[SqlQuery]")
        {
        }
    }
}