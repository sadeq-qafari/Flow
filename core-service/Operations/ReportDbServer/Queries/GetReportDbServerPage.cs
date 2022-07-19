using Core.Meteor;
using Core.Operations.ReportDbServer.Dtos;
using Humanizer;
using Meteor.Database.SqlDialect;

namespace Core.Operations.ReportDbServer.Queries
{
    public class GetReportDbServerPage : DbQueryPage<ReportDbServerDto>
    {
        public GetReportDbServerPage() : base("[Core].[ReportDbServer]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("EngineTypeLookup", SqServices.GetModelProperty("Core","ReportDbServer","engineTypeLookup")!.Id);
            return SqlFactory!.Create().Select("[Core].[ReportDbServer] ReportDbServer", isForCount ? "COUNT(*)" : @"
						ReportDbServer.*, 
						EngineTypeLookup.Title AS EngineTypeLookupTitle")
                .LeftJoin("[Core].[ModelPropertyLookup] EngineTypeLookup",  "ReportDbServer.EngineTypeLookup = EngineTypeLookup.Value AND EngineTypeLookup.ModelPropertyId=@EngineTypeLookup  AND  EngineTypeLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "EngineTypeLookupTitle" => "EngineTypeLookup.Title",
                _ => $"[ReportDbServer].[{fieldName}]"
            };
        }
    }
}