using Core.Operations.Model.Dto;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Core.Operations.Model.Queries
{
    public class GetModel : SaanaaDbSelectAsync<ModelDto?>
    {
        public GetModel() : base("[Core].[Model]")
        {
        }

        protected override ISqlDialect GetSql()
        {
            return SqlFactory!.Create().Select("[Core].[Model] Model",
                    @"Model.* 
                                 ,Service.Name AS ServiceName
                                 ,Service.Title AS ServiceTitle")
                .InnerJoin("[Core].[Service] Service", "Service.Id = Model.ServiceId")
                .Where("Model.Id=@Id AND Model.IsDeleted=0 AND (ISNULL(Model.TenantId,0)=0 OR Model.TenantId=@TenantId)");
        }
    }
}
