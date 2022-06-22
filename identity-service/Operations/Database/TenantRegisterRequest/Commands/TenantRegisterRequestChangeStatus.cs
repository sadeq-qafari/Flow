using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Operations.Database.TenantRegisterRequest.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;
using Saanaa.Core.AspNetCore.Operations.Logic.SendMessage;
using Saanaa.Core.AspNetCore.Operations.Logic.SendMessage.Dto;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Commands
{
    public class TenantRegisterRequestChangeStatus : DbOperationAsync<TenantRegisterRequestChangeStatusInDto, TenantRegisterRequestChangeStatusDto>,INeedLog,IHaveTableName
    {
        public string TableName { get; set; } = "[Identity].[Tenant]";
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE [Identity].sp_TenantRegisterRequestChangeStatus
                                        @Id = @Id
                                       ,@TenantName = @TenantName")
                .QueryFirstOrDefaultAsync<TenantRegisterRequestChangeStatusDto>();
        }

        protected override async Task OnSuccessAsync()
        {
            try
            {
                var apiClient = OperationFactory!.GetService<ApiClient>()
                                ?? throw Errors.InternalError("api_client_not_registered");

                var msgId = await OperationFactory!.New<SendMessage>().ExecuteAsync(
                    new SendMessageInDto
                    {
                        MessageName = "TenantRegisterConfirm",
                        Receivers = Output.PhoneNumber,
                        TenantId = SaanaaTenants.Tenants.First(x => x.Name.ToLowerInvariant() == "hamiane")?.Id,
                        Params = new List<string>()
                        {
                            "https://my.hamiane.com",
                            "",
                            "",
                            "حامیانه",
                        }
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
