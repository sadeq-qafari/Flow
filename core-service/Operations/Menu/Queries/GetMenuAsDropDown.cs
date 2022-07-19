using Core.Meteor;
using Meteor.Database.SqlDialect;

namespace Core.Operations.Menu.Queries
{
    public class GetMenuAsDropDown : DbQueryAsDropDown<Menu>
    {
        public GetMenuAsDropDown() : base("[Core].[Menu]", "Title", "Id", "Name")
        {
        }

        protected override ISqlDialect GetSelectSql(ISqlDialect sql) =>
            SqlFactory!.Create().Select("[Core].[Menu]");
    }
}
