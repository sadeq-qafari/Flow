using Humanizer;
using Core.Meteor;
using Tenant.Operations.OrganizationDetail.Dtos;

namespace Tenant.Operations.OrganizationDetail.Queries
{
    public class GetOrganizationDetailPage : DbQueryPage<OrganizationDetailDto>
    {
        public GetOrganizationDetailPage() : base("[Tenant].[OrganizationDetail]")
        {
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "ApplicationName" => "OrganizationDetail.[Key]", 
                _ => $"OrganizationDetail.{fieldName}"
            };
        }
    }
}