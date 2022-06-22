using Saanaa.Core.Meteor;

namespace Flow.Operations.SqlQuery.Queries
{
    public class GetSqlQueryByIds : SaanaaDbQueryByIds<SqlQuery>
    {
        public GetSqlQueryByIds() : base("[Flow].[SqlQuery]")
        {
        }
    }
}