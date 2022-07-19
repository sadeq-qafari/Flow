using Identity.Operations.Database.Role.Dtos;
using Meteor.Database.SqlDialect;
using Core.Meteor;

namespace Identity.Operations.Database.Role.Queries
{
    public class GetRolePage : DbQueryPage<RoleDto>
    {
        public GetRolePage() : base("[Identity].[Role]")
        {
        }

        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Identity].[Role] Role", isForCount
                    ? "COUNT(*)"
                    : @"Role.*, 
						Service.Title AS ServiceTitle")
                .LeftJoin("[Core].[Service] Service", "Role.ServiceId = Service.Id  AND  Service.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[Role].[{fieldName}]";
    }
}
