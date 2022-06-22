using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;
using Tenant.Operations.Organization.Dto;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganization : SaanaaDbSelectAsync<OrganizationDto?>
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
