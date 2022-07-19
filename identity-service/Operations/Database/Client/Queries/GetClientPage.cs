using Identity.Operations.Database.Client.Dtos;
using Meteor.Database.SqlDialect;
using Core.Meteor;

namespace Identity.Operations.Database.Client.Queries
{
    public class GetClientPage : DbQueryPage<ClientDto>
    {
        public GetClientPage() : base("[Identity].[Client]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Identity].[Client] Client", isForCount ? "COUNT(*)" : @"
						Client.*, 
						Client.Title AS ClientTitle,
						IncludeJwt.Title AS IncludeJwtTitle")
                .LeftJoin("[Identity].[Client] Client",  "Client.ClientId = Client.Id  AND  Client.IsDeleted=0")
                .LeftJoin("[Identity].[Client] IncludeJwt",  "Client.IncludeJwtId = IncludeJwt.Id  AND  IncludeJwt.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[Client].[{fieldName}]";
    }
}