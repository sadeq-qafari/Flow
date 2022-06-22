using Flow.Operations.SqlQuery.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.SqlQuery.Queries
{
    public class GetSqlQueryPage : SaanaaDbQueryPage<SqlQueryDto>
    {
        public GetSqlQueryPage() : base("[Flow].[SqlQuery]")
        {
        }
        
    }
}