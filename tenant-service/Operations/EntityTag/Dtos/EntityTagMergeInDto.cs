using System.Collections.Generic;

namespace Tenant.Operations.EntityTag.Dtos
{
    public class EntityTagMergeInDto
    {
        public string ServiceName { get; set; }
        public string ModelName { get; set; }
        public int EntityId { get; set; }
        public List<int>? TagIds { get; set; }

        public int? TenantId { get; set; }
        public int CreatedBy { get; set; }
    }
}
