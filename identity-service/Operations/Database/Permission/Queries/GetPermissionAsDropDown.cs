using Meteor.Database.SqlDialect;
using Core.Meteor;

namespace Identity.Operations.Database.Permission.Queries
{
    public class GetPermissionAsDropDown : DbQueryAsDropDown<Permission>
    {
        public GetPermissionAsDropDown() : base("[Identity].[Permission]","Name")
        {
        }

        protected override void GetSearchValueWhere(SqlWhereBuilder wb) =>
            wb.When(!string.IsNullOrWhiteSpace(Input.SearchValue),
                $"Name Like N'%{Input.SearchValue?.Trim()}%' OR Title Like N'%{Input.SearchValue?.Trim()}%'");
    }
}
