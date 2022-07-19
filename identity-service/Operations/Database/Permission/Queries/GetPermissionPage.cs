using Identity.Operations.Database.Permission.Dtos;
using Meteor.Database.SqlDialect;
using Core.Meteor;

namespace Identity.Operations.Database.Permission.Queries
{
    public class GetPermissionPage : DbQueryPage<PermissionDto>
    {
        public GetPermissionPage() : base("[Identity].[Permission]")
        {
        }



        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("TypeLookup", SqServices.GetModelProperty("Identity","Permission","typeLookup")!.Id);
            return SqlFactory!.Create().Select("[Identity].[Permission] Permission", isForCount ? "COUNT(*)" : @"
						Permission.*, 
						TypeLookup.Title AS TypeLookupTitle")
                .LeftJoin("[Core].[ModelPropertyLookup] TypeLookup",  "Permission.TypeLookup = TypeLookup.Value AND TypeLookup.ModelPropertyId=@TypeLookup  AND  TypeLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[Permission].[{fieldName}]";
    }
}
