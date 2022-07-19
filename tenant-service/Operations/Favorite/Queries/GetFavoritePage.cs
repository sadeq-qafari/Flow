using Humanizer;
using Meteor.Database.SqlDialect;
using Core.Meteor;
using Tenant.Operations.Favorite.Dtos;

namespace Tenant.Operations.Favorite.Queries
{
    public class GetFavoritePage : DbQueryPage<FavoriteDto>
    {
        public GetFavoritePage() : base("[Tenant].[Favorite]")
        {
        }


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Tenant].[Favorite] Favorite", isForCount
                        ? "COUNT(*)"
                        : @"
						Favorite.*, 
						Model.Title AS ModelTitle,
                        Person.Title AS PersonTitle")
                    .LeftJoin("[Core].[Model] Model", "Favorite.ModelId = Model.Id  AND  Model.IsDeleted=0")
                    .LeftJoin("[Tenant].[Person] Person", "Favorite.PersonId = Person.Id  AND Favorite.TenantId = Person.TenantId AND  Person.IsDeleted=0")
                ;
        }

        protected override string GetFieldName(string fieldName) =>
            fieldName.Pascalize() switch
            {
                "ModelTitle" => "Model.Title",
                "PersonTitle" => "Person.Title",
                _ => $"[Favorite].[{fieldName}]"
            };
    }
}