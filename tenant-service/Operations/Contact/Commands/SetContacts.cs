using System.Threading.Tasks;
using Dapper;
using Meteor.Operation.Db;
using Meteor.Utils;
using Core.Meteor;
using Core.Meteor.Extensions;
using Tenant.Operations.Contact.Dto;

namespace Tenant.Operations.Contact.Commands
{
    public class SetContacts : DbOperationAsync<SetContactsInDto, bool>, INeedLog, IHaveTableName
    {
        public string TableName { get; set; } = "[Tenant].[Contact]";

        protected override async Task ExecutionAsync()
        {
            var dt = Input.Contacts.AsDataTable("[Tenant].[udt_Contact]", x => new
            {
                x.Id,
                x.Title,
                x.Value
            });

            var modelId = SqServices.GetModel(Input.ServiceName, Input.ModelName)?.Id ??
                          throw Errors.InvalidInput("model_not_found");

            var parameters = new DynamicParameters();
            parameters.Add("ModelId", modelId);
            parameters.Add("EntityId", Input.EntityId);
            parameters.Add("Contacts", dt.AsTableValuedParameter("[Tenant].[udt_Contact]"));
            parameters.Add("ActionBy", Input.ActionBy);
            parameters.Add("TenantId", Input.TenantId);

            Output = await NewSql(@"EXECUTE Tenant.sp_ContactSet 
                                  @ModelId = @ModelId
                                  ,@EntityId = @EntityId
                                  ,@Contacts = @Contacts
                                  ,@ActionBy = @ActionBy
                                  ,@TenantId = @TenantId", parameters).ExecuteAsync() > 0;
        }
    }
}
