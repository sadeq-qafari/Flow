using System.Collections.Generic;
using Meteor.Operation.Db.Default;
using Core.Meteor;

namespace Tenant.Operations.OrganizationDetail.Dtos
{
    public class OrganizationDetailUpsertInDto : IHaveActionBy, IDbModel<int?>
    {
        public int? OrganizationId { get; set; }
        public int ActionBy { get; set; }
        public Dictionary<string, object?> Details { get; set; }
        public int? Id => OrganizationId;
    }
}
