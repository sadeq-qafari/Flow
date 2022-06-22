using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Core.Operations.Menu.Queries
{
    public class GetMenuAsDropDown : SaanaaDbQueryAsDropDown<Menu>
    {
        public GetMenuAsDropDown() : base("[Core].[Menu]", "Title", "Id", "Name")
        {
        }

        protected override ISqlDialect GetSelectSql(ISqlDialect sql) =>
            SqlFactory!.Create().Select("[Core].[Menu]");
    }
}
