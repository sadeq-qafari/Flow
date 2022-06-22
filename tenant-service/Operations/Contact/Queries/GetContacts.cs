using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Meteor.Utils;
using Saanaa.Core.Meteor;
using Tenant.Operations.Contact.Dto;

namespace Tenant.Operations.Contact.Queries
{
    public class GetContacts : DbOperationAsync<GetContactsInDto, IEnumerable<ContactsDto>>
    {
        protected override async Task ExecutionAsync()
        {
            var modelId = SaanaaServices.GetModel(Input.ServiceName, Input.ModelName)?.Id ??
                          throw Errors.InvalidInput("model_not_found");
            Output = await NewSql(sql => sql
                    .Select("[Tenant].[Contact] Contact")
                    .Where("Contact.IsDeleted = 0 AND Contact.ModelId = @ModelId AND Contact.EntityId = @EntityId"),
                new {ModelId = modelId, Input.EntityId}
            ).QueryAsync<ContactsDto>();
        }
    }
}
