using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;
using Tenant.Operations.Branch.Dtos;

namespace Tenant.Operations.Branch.Queries
{
    public class GetBranchPage : SaanaaDbQueryPage<BranchDto>
    {
        public GetBranchPage() : base("[Tenant].[Branch]")
        {
        }


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Identity].[Branch] Branch", isForCount
                    ? "COUNT(*)"
                    : @" Branch.Id
                        ,Branch.CityId
                        ,Branch.ParentId
                        ,Branch.Title
                        ,Branch.Phone
                        ,Branch.Fax
                        ,Branch.Address
                        ,Branch.GeoLocation.ToString() AS GeoLocation
                        ,Branch.PostalCode
                        ,Branch.IsActive
                        ,Branch.IsDeleted
                        ,Branch.CreatedBy
                        ,Branch.CreatedAt
                        ,Branch.ModifiedBy
                        ,Branch.ModifiedAt
                        ,Branch.TenantId
						,Tenant.Title AS TenantTitle
						,City.Title AS CityTitle
                        ,Parent.Title AS ParentTitle")
                .LeftJoin("[Identity].[Tenant] Tenant", "Branch.TenantId = Tenant.Id  AND  Tenant.IsDeleted=0")
                .LeftJoin("[Identity].[Branch] Parent", "Branch.ParentId = Parent.Id  AND  Parent.IsDeleted=0")
                .LeftJoin("[Base].[City] City", "Branch.CityId = City.Id  AND  City.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[Branch].[{fieldName}]";
    }
}
