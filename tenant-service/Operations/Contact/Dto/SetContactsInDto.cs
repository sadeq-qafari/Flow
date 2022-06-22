using System.Collections.Generic;
using Meteor.Operation.Db.Default;

namespace Tenant.Operations.Contact.Dto
{
    public class SetContactsInDto : IDbModel<int?>
    {
        public string ServiceName { get; set; }
        public string ModelName { get; set; }
        public int EntityId { get; set; }
        public List<ContactsDto> Contacts { get; set; }
        public int ActionBy { get; set; }
        public int TenantId { get; set; }
        public int? Id => EntityId;
    }
}
