using Core.Meteor;
using Core.Operations.Model.Dto;
using Meteor.Database.SqlDialect;

namespace Core.Operations.Model.Queries
{
    public class GetModelAsDropDown : DbQueryAsDropDown<ModelDto>
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
