using Saanaa.Core.Meteor;

namespace Flow.Operations.SqlQuery.Commands
{
    public class SqlQueryRemove : SaanaaDbDeleteAsync
    {
        public SqlQueryRemove() : base("[Flow].[SqlQuery]")
        {
        }
    }
}