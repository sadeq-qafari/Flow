using Meteor.Database.SqlDialect;
using Core.Meteor;
using Tenant.Operations.Dashboard.Dtos;

namespace Tenant.Operations.Dashboard.Queries
{
    public class GetDashboardPage : DbQueryPage<DashboardDto>
    {
        public GetDashboardPage() : base("[Tenant].[Dashboard]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Tenant].[Dashboard] Dashboard", isForCount ? "COUNT(*)" : @"
						Dashboard.*, 
						Person.Title AS PersonTitle")
                .LeftJoin("[Tenant].[Person] Person",  "Dashboard.PersonId = Person.Id  AND  Person.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[Dashboard].[{fieldName}]";
    }
}