using Core.Meteor;
using Core.Operations.EntityRelationRule.Dto;
using Humanizer;
using Meteor.Database.SqlDialect;

namespace Core.Operations.EntityRelationRule.Queries
{
    public class GetEntityRelationRulePage : DbQueryPage<EntityRelationRuleDto>
    {
        public GetEntityRelationRulePage() : base("[Core].[EntityRelationRule]")
        {
        }



        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Core].[EntityRelationRule] EntityRelationRule", isForCount ? "COUNT(*)" : "EntityRelationRule.*, Model1.Title AS ModelTitleA, Model2.Title AS ModelTitleB")
                .LeftJoin("[Core].[Model] Model1", "EntityRelationRule.ModelIdA=Model1.Id AND Model1.IsDeleted=0")
                .LeftJoin("[Core].[Model] Model2", "EntityRelationRule.ModelIdB=Model2.Id AND Model2.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "ModelTitleA" => "Model1.Title",
                "ModelTitleB" => "Model2.Title",
                _ => $"[EntityRelationRule].[{fieldName}]"
            };
        }
    }
}
