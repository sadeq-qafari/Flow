using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;
using Tenant.Operations.EntityTag.Dtos;

namespace Tenant.Operations.EntityTag.Queries
{
    public class GetEntityTagPage : SaanaaDbQueryPage<EntityTagDto>
    {
        public GetEntityTagPage() : base("[Tenant].[EntityTag]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Tenant].[EntityTag] EntityTag", isForCount ? "COUNT(*)" : @"
						EntityTag.*, 
						Model.Title AS ModelTitle,
						Tag.Title AS TagTitle")
                .LeftJoin("[Core].[Model] Model",  "EntityTag.ModelId = Model.Id  AND  Model.IsDeleted=0")
                .LeftJoin("[Tenant].[Tag] Tag",  "EntityTag.TagId = Tag.Id  AND  Tag.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[EntityTag].[{fieldName}]";
    }
}