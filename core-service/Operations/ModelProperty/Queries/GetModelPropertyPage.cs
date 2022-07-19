using Core.Meteor;
using Core.Operations.ModelProperty.Dto;
using Humanizer;
using Meteor.Database.SqlDialect;

namespace Core.Operations.ModelProperty.Queries
{
    public class GetModelPropertyPage : DbQueryPage<ModelPropertyDto>
    {
        public GetModelPropertyPage() : base("[Core].[ModelProperty]")
        {
        }

        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Core].[ModelProperty] ModelProperty", isForCount ? "COUNT(*)" : "ModelProperty.*, Model1.Title AS ModelTitle, ModelPropertyDatagrid2.Name AS ModelPropertyDatagridTitle, ModelPropertyElement3.Name AS ModelPropertyElementTitle, Model4.Title AS RelatedModelTitle, ModelProperty5.Title AS RelatedModelPropertyTitle")
                .LeftJoin("[Core].[Model] Model1", "ModelProperty.ModelId=Model1.Id AND Model1.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyDatagrid] ModelPropertyDatagrid2", "ModelProperty.ModelPropertyDatagridId=ModelPropertyDatagrid2.Id AND ModelPropertyDatagrid2.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyElement] ModelPropertyElement3", "ModelProperty.ModelPropertyElementId=ModelPropertyElement3.Id AND ModelPropertyElement3.IsDeleted=0")
                .LeftJoin("[Core].[Model] Model4", "ModelProperty.RelatedModelId=Model4.Id AND Model4.IsDeleted=0")
                .LeftJoin("[Core].[ModelProperty] ModelProperty5", "ModelProperty.RelatedModelPropertyId=ModelProperty5.Id AND ModelProperty5.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "ModelTitle" => "Model1.Title",
                "ModelPropertyDatagridTitle" => "ModelPropertyDatagrid2.Name",
                "ModelPropertyElementTitle" => "ModelPropertyElement3.Name",
                "RelatedModelTitle" => "Model4.Title",
                "RelatedModelPropertyTitle" => "ModelProperty5.Title",
                _ => $"[ModelProperty].[{fieldName}]"
            };
        }
    }
}
