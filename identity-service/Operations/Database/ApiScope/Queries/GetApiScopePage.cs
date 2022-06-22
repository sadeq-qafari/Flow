using Identity.Operations.Database.ApiScope.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Queries
{
    public class GetApiScopePage : SaanaaDbQueryPage<ApiScopeDto>
    {
        public GetApiScopePage() : base("[Identity].[ApiScope]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Identity].[ApiScope] ApiScope", isForCount ? "COUNT(*)" : @"
						ApiScope.*, 
						ApiResource.Title AS ApiResourceTitle")
                .LeftJoin("[Identity].[ApiScope] ApiResource",  "ApiScope.ApiResourceId = ApiResource.Id  AND  ApiResource.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[ApiScope].[{fieldName}]";
    }
}