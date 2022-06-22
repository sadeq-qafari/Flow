using Core.Operations.Model.Dto;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Core.Operations.Model.Queries
{
    public class GetModelAsDropDown : SaanaaDbQueryAsDropDown<ModelDto>
    {
        public GetModelAsDropDown() : base("[Core].[Model]","Title","Id","ServiceTitle")
        {
        }

        protected override ISqlDialect GetSelectSql(ISqlDialect sql)
        {
            return SqlFactory!.Create().Select("[Core].[Model] Model","Model.Title, Model.Id, Service.Title AS ServiceTitle")
                .InnerJoin("[Core].[Service] Service", "ServiceId=Service.Id AND Service.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"Model.[{fieldName}]" ;
    }
}
