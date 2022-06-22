using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Menu.Queries
{
    public class GetMenuAsDropDown : SaanaaDbQueryAsDropDown<Menu>
    {
        public GetMenuAsDropDown() : base("[Flow].[Menu]", "Title", "Id", "Name")
        {
        }

        protected override ISqlDialect GetSelectSql(ISqlDialect sql) =>
            SqlFactory!.Create().Select("[Flow].[Menu]");
    }
}
