using Core.Meteor;
using Core.Operations.Application.Dtos;
using Humanizer;
using Meteor.Database.SqlDialect;

namespace Core.Operations.Application.Queries
{
    public class GetApplicationPage : DbQueryPage<ApplicationDto>
    {
        public GetApplicationPage() : base("[Core].[Application]")
        {
        }
        
        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            return SqlFactory!.Create().Select("[Core].[Application] Application", isForCount ? "COUNT(*)" : "Application.*, GatewayDetail.Title AS GatewayDetailTitle")
                .LeftJoin("[Payment].[GatewayDetail] GatewayDetail", "Application.GatewayDetailId=GatewayDetail.Id AND GatewayDetail.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName)
        {
            return fieldName.Pascalize() switch
            {
                "GatewayDetailTitle" => "GatewayDetail.Title",
                _ => $"[Application].{fieldName}"
            };
        }
    }
}