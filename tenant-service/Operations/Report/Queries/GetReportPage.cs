using Meteor.Database.SqlDialect;
using Core.Meteor;
using Tenant.Operations.Report.Dtos;

namespace Tenant.Operations.Report.Queries
{
    public class GetReportPage : DbQueryPage<ReportDto>
    {
        public GetReportPage() : base("[Tenant].[Report]")
        {
        }



        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("TypeLookup", SqServices.GetModelProperty("Tenant","Report","typeLookup")!.Id);
            return SqlFactory!.Create().Select("[Tenant].[Report] Report", isForCount ? "COUNT(*)" : @"
						Report.*,
						TypeLookup.Title AS TypeLookupTitle")
                .LeftJoin("[Core].[ModelPropertyLookup] TypeLookup",  "Report.TypeLookup = TypeLookup.Value AND TypeLookup.ModelPropertyId=@TypeLookup  AND  TypeLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[Report].[{fieldName}]";
    }
}
