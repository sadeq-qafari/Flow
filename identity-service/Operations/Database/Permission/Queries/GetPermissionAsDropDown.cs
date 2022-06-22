using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Permission.Queries
{
    public class GetPermissionAsDropDown : SaanaaDbQueryAsDropDown<Permission>
    {
        public GetPermissionAsDropDown() : base("[Identity].[Permission]","Name")
        {
        }

        protected override void GetSearchValueWhere(SqlWhereBuilder wb) =>
            wb.When(!string.IsNullOrWhiteSpace(Input.SearchValue),
                $"Name Like N'%{Input.SearchValue?.Trim()}%' OR Title Like N'%{Input.SearchValue?.Trim()}%'");
    }
}
