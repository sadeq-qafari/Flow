using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganizationAsDropDown : SaanaaDbQueryAsDropDown<Organization>
    {
        public GetOrganizationAsDropDown() : base("[Tenant].[Organization]")
        {
        }

        protected override SqlWhereBuilder GetWhereSql(SqlWhereBuilder whereBuilder) =>
            whereBuilder.Where($"{GetFieldName("IsDeleted")}=0");
    }
}
