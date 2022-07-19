using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Meteor.Operation.Db;
using Meteor.Utils;
using Core.Meteor;
using Core.Meteor.Extensions;
using Tenant.Operations.OrganizationDetail.Dtos;

namespace Tenant.Operations.OrganizationDetail.Commands
{
    public class OrganizationDetailUpsert : DbOperationAsync<OrganizationDetailUpsertInDto, bool>,INeedLog,IHaveTableName
    {
        public string TableName { get; set; } = "[Tenant].[OrganizationDetail]";
        protected override async Task ExecutionAsync()
        {
            Dictionary<string, string?> details =
                Input.Details.ToDictionary(x => x.Key.ToString(), x => x.Value?.ToString().TrimStart('\"').TrimEnd('\"'));
            var dt = details.AsDataTable("Tenant.udt_OrganizationDetail", x => new
            {
                x.Key,
                x.Value
            });
            var parameters = new DynamicParameters();
            parameters.Add("ActionBy", Input.ActionBy);
            parameters.Add("TenantId", Input.OrganizationId);
            parameters.Add("Items", dt.AsTableValuedParameter("Tenant.udt_OrganizationDetail"));
            Output = await NewSql(@"EXECUTE Tenant.sp_OrganizationDetailUpsert @Items = @Items
                                          ,@TenantId = @TenantId
                                          ,@ActionBy = @ActionBy", parameters).ExecuteAsync()
                .ValidateDatabaseAffectedRows() > 0;
        }

    }
}
