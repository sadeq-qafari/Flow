using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Meteor.Models;
using Dapper;
using Meteor.Database;
using Microsoft.AspNetCore.Http;

namespace Core.Meteor
{
    public static class SqTenants
    {
        public static List<Tenant> Tenants { get; private set; } = new List<Tenant>();

        public static async Task Reload(LazyDbConnection lazyDbConnection)
        {
            const string sqlText = @"
SELECT Tenant.Id
      ,Tenant.Name
      ,Tenant.Title
      ,Tenant.ApplicationId
FROM [Identity].[Tenant] Tenant
";
            var db = await lazyDbConnection.GetConnectionAsync();
            Tenants = (await db.QueryAsync<Tenant>(sqlText)).ToList();
            const string sqlTextUrls = @"
SELECT
      TenantUrl.Url
     ,TenantUrl.TenantId
     ,TypeLookup.Title Type
FROM [Identity].TenantUrl
INNER JOIN Core.v_Lookup TypeLookup
    ON TypeLookup = Value
       AND ServiceName = 'identity'
       AND ModelName = 'tenanturl'
       AND ModelPropertyName = 'typelookup'
ORDER BY IsDefault DESC";

            const string sqlTextCredits = @"
SELECT
      TenantId
     ,SUM(IIF(IsDeposit = 1, Amount, Amount * -1)) Credit
FROM tenant.[Transaction]
WHERE PersonId = 0
GROUP BY TenantId
";

            var urls = (await db.QueryAsync<TenantUrl>(sqlTextUrls)).ToList();
            var credits = (await db.QueryAsync<TenantCredit>(sqlTextCredits)).ToList();
            foreach (var tenant in Tenants)
            {
                tenant.Urls = new Dictionary<string, string>();
                foreach (var tenantUrl in urls.Where(x => x.TenantId == tenant.Id))
                {
                    var count = tenant.Urls.Keys.Count(x => x.Contains(tenantUrl.Type));
                    tenant.Urls.Add($"{tenantUrl.Type}{(count > 0 ? count : "")}", tenantUrl.Url);
                }

                tenant.Credit = credits.FirstOrDefault(x => x.TenantId == tenant.Id)?.Credit ?? 0;
            }
        }


        public static Tenant? GetTenant(int id) =>
            Tenants.FirstOrDefault(x => x.Id == id);


        public static Tenant? GetTenant(string url) =>
            Tenants.FirstOrDefault(x => x.Urls.Any(y => y.Value.Contains(url)));

        public static Tenant? GetTenant(HttpRequest request)
        {
            var url = request.Headers["Sq-Origin"].FirstOrDefault() ?? request.Headers["origin"].FirstOrDefault();
            return url == null ? null : GetTenant(url);
        }

        public static Tenant? GetTenant(HttpContext httpContext)
        {
            var url = httpContext.Request.Headers["Sq-Origin"].FirstOrDefault() ??
                      httpContext.Request.Headers["origin"].FirstOrDefault();
            return url == null ? null : GetTenant(url);
        }


        public static async Task<decimal?> GetTenantCredit(int? id, LazyDbConnection lazyDbConnection)
        {
            var sqlText = @"
SELECT
      SUM(IIF(IsDeposit = 1, Amount, Amount * -1)) 
FROM tenant.[Transaction]
WHERE PersonId = 0 AND TenantId = @TenantId
";
            var db = await lazyDbConnection.GetConnectionAsync();
            var credit = await db.ExecuteScalarAsync<decimal>(sqlText, new { TenantId = id });
            if (Tenants.Any(x => x.Id == id))
            {
                Tenants.FirstOrDefault(x => x.Id == id)!.Credit = credit;
                return Tenants.FirstOrDefault(x => x.Id == id)?.Credit ?? 0;
            }
            else
            {
                return 0;
            }
        }

        public static async Task<bool> IsPermanent(int? id, LazyDbConnection lazyDbConnection)
        {
            var sqlText = @"SELECT Tenant.fn_PricingIsPermanent(@TenantId)";
            var db = await lazyDbConnection.GetConnectionAsync();
            return await db.ExecuteScalarAsync<bool>(sqlText, new { TenantId = id });
        }
    }
}
