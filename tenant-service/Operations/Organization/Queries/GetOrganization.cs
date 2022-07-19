using Meteor.Database.SqlDialect;
using Core.Meteor;
using Tenant.Operations.Organization.Dto;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganization : DbSelectAsync<OrganizationDto?>
    {
        public GetOrganization() : base("[Tenant].[Organization]")
        {
        }

        protected override ISqlDialect GetSql()
        {
            return SqlFactory!.Create().Select("[Tenant].[Organization] Organization",
                    @"Organization.*, Application.Name as ApplicationName")
                .LeftJoin("[Identity].[Tenant] Tenant", "Organization.Id = Tenant.Id")
                .LeftJoin("[Core].[Application] Application", "Tenant.ApplicationId = Application.Id")
                .Where("Organization.Id=@Id");
        }
    }
}
