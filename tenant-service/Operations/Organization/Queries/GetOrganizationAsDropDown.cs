using Meteor.Database.SqlDialect;
using Core.Meteor;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganizationAsDropDown : DbQueryAsDropDown<Organization>
    {
        public GetOrganizationAsDropDown() : base("[Tenant].[Organization]")
        {
        }

        protected override SqlWhereBuilder GetWhereSql(SqlWhereBuilder whereBuilder) =>
            whereBuilder.Where($"{GetFieldName("IsDeleted")}=0");
    }
}
