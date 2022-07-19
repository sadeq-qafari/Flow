using Core.Meteor;
using Core.Operations.ModelReport.Dtos;
using Meteor.Database.SqlDialect;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReportPage : DbQueryPage<ModelReportDto>
    {
        public GetModelReportPage() : base("[Core].[ModelReport]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Core].[ModelReport] ModelReport", isForCount ? "COUNT(*)" : @"
						ModelReport.*, 
						Model.Title AS ModelTitle,
						Report.Title AS ReportTitle")
                .LeftJoin("[Core].[Model] Model",  "ModelReport.ModelId = Model.Id  AND  Model.IsDeleted=0")
                .LeftJoin("[Core].[Report] Report",  "ModelReport.ReportId = Report.Id  AND  Report.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[ModelReport].[{fieldName}]";
    }
}