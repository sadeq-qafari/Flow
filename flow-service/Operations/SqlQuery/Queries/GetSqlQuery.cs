using Saanaa.Core.Meteor;

namespace Flow.Operations.SqlQuery.Queries
{
    public class GetSqlQuery : SaanaaDbSelectAsync<SqlQuery?>
    {
        public GetSqlQuery() : base("[Flow].[SqlQuery]")
        {
        }
    }
}