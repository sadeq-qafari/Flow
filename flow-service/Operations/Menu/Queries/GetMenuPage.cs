using Flow.Operations.Menu.Dto;
using Humanizer;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Menu.Queries
{
    public class GetMenuPage : SaanaaDbQueryPage<MenuDto>
    {
        public GetMenuPage() : base("[Flow].[Menu]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Flow].[Menu] Menu", isForCount ? "COUNT(*)" : "Menu.*, Menu1.Title AS ParentTitle")
                .LeftJoin("[Flow].[Menu] Menu1", "Menu.ParentId=Menu1.Id AND Menu1.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "ParentTitle" => "Menu1.Title",
                _ => $"[Menu].[{fieldName}]"
            };
        }
    }
}
