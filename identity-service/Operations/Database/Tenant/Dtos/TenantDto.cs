using System.Collections.Generic;

namespace Identity.Operations.Database.Tenant.Dtos
{
    public class TenantDto : Tenant
    {
        public Dictionary<string,string> Urls { get; set; }
    }
}
