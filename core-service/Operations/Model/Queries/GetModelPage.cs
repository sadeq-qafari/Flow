using Core.Meteor;
using Core.Operations.Model.Dto;
using Humanizer;
using Meteor.Database.SqlDialect;

namespace Core.Operations.Model.Queries
{
    public class GetModelPage : DbQueryPage<ModelDto>
    {
        public GetModelPage() : base("[Core].[Model]")
        {
        }

        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Core].[Model] Model", isForCount ? "COUNT(*)" : "Model.*, Service1.Title AS ServiceTitle")
                .LeftJoin("[Core].[Service] Service1", "Model.ServiceId=Service1.Id AND Service1.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "ServiceTitle" => "Service1.Title",
                _ => $"[Model].[{fieldName}]"
            };
        }
    }
}
