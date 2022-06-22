using Core.Operations.ModelProperty.Dto;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelProperty.Queries
{
    public class GetModelPropertyAsDropDown : SaanaaDbQueryAsDropDown<ModelPropertyDto>
    {
        public GetModelPropertyAsDropDown() : base("[Core].[ModelProperty]", "Title", "Id", "Name","ModelTitle")
        {
        }

        protected override ISqlDialect GetSelectSql(ISqlDialect sql)
        {
            return sql.Select("[Core].[ModelProperty] ModelProperty",
                    "ModelProperty.Id, ModelProperty.Name, ModelProperty.Title,Model.Title AS ModelTitle")
                .LeftJoin("[Core].[Model]", "ModelProperty.ModelId = Model.Id AND Model.IsDeleted = 0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return $"ModelProperty.{fieldName}";
        }
    }
}
