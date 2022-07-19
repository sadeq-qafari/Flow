using Core.Meteor;
using Meteor.Database.SqlDialect;

namespace Flow.Operations.Menu.Queries
{
    public class GetMenuAsDropDown : DbQueryAsDropDown<Menu>
    {
        public GetMenuAsDropDown() : base("[Flow].[Menu]", "Title", "Id", "Name")
        {
        }

        protected override ISqlDialect GetSelectSql(ISqlDialect sql) =>
            SqlFactory!.Create().Select("[Flow].[Menu]");
    }
}
