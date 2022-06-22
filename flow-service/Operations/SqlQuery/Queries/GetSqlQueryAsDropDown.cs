using Saanaa.Core.Meteor;

namespace Flow.Operations.SqlQuery.Queries
{
    public class GetSqlQueryAsDropDown : SaanaaDbQueryAsDropDown<SqlQuery>
    {
        public GetSqlQueryAsDropDown() : base("[Flow].[SqlQuery]")
        {
        }
    }
}
