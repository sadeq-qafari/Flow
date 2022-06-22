using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Tenant.Operations.Person.Queries
{
    public class GetPersonAsDropDown : SaanaaDbQueryAsDropDown<Person>
    {
        public GetPersonAsDropDown() : base("[Tenant].[Person]")
        {
        }

        protected override ISqlDialect GetSelectSql(ISqlDialect sql) =>
            SqlFactory!.Create()
                .Select("[Tenant].[Person] Person", "Person.Id, Person.FirstName, Person.LastName");

        protected override void GetSearchValueWhere(SqlWhereBuilder wb) =>
            wb.When(!string.IsNullOrWhiteSpace(Input.SearchValue),
                $"Person.FirstName + space(1) + Person.LastName Like N'%{Input.SearchValue?.Trim()}%' ");

        protected override string GetFieldName(string fieldName) =>
            $"Person.{fieldName}";
    }
}
