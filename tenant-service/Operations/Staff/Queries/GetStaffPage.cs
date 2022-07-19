using Humanizer;
using Meteor.Database.SqlDialect;
using Core.Meteor;
using Tenant.Operations.Staff.Dtos;

namespace Tenant.Operations.Staff.Queries
{
    public class GetStaffPage : DbQueryPage<StaffDto>
    {
        public GetStaffPage() : base("[Tenant].[v_Staff]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("GenderLookup", SqServices.GetModelProperty("Tenant","Staff","genderLookup")!.Id);
            return SqlFactory!.Create().Select("[Tenant].[v_Staff] Staff", isForCount ? "COUNT(*)" : @"
						Staff.*, 
						GenderLookup.Title AS GenderLookupTitle")
                .LeftJoin("[Core].[ModelPropertyLookup] GenderLookup",  "Staff.GenderLookup = GenderLookup.Value AND GenderLookup.ModelPropertyId=@GenderLookup  AND  GenderLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "GenderLookupTitle" => "GenderLookup.Title",
                _ => $"[Staff].[{fieldName}]"
            };
        }
    }
}