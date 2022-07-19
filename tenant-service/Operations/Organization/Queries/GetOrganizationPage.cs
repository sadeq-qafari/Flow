using Humanizer;
using Meteor.Database.SqlDialect;
using Core.Meteor;
using Tenant.Operations.Organization.Dto;

namespace Tenant.Operations.Organization.Queries
{
    public class GetOrganizationPage : DbQueryPage<OrganizationDto>
    {
        public GetOrganizationPage() : base("[Tenant].[Organization]")
        {
        }

        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Tenant].[Organization] Organization",
                    isForCount ? "Count(*)" : @"Organization.*, City.Title as CityTitle")
                .LeftJoin("[Base].[City] City", "Organization.CityId = City.Id");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "CityTitle" => "City.Title",
                _ => $"Organization.[{fieldName}]"
            };
        }
    }
}
