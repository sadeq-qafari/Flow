using Core.Operations.EntityRelation.Dto;
using Humanizer;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Core.Operations.EntityRelation.Queries
{
    public class GetEntityRelationPage : SaanaaDbQueryPage<EntityRelationDto>
    {
        public GetEntityRelationPage() : base("[Core].[EntityRelation]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Core].[EntityRelation] EntityRelation", isForCount ? "COUNT(*)" : "EntityRelation.*, Model1.Title AS ModelTitleA, Model2.Title AS ModelTitleB")
                .LeftJoin("[Core].[Model] Model1", "EntityRelation.ModelIdA=Model1.Id AND Model1.IsDeleted=0")
                .LeftJoin("[Core].[Model] Model2", "EntityRelation.ModelIdB=Model2.Id AND Model2.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "ModelTitleA" => "Model1.Title",
                "ModelTitleB" => "Model2.Title",
                _ => $"[EntityRelation].[{fieldName}]"
            };
        }
    }
}
