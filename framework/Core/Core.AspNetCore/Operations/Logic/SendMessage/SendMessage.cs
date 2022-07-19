using System.Threading.Tasks;
using Core.AspNetCore.Operations.Logic.SendMessage.Dto;
using Core.Meteor;
using Meteor.Operation;
using Meteor.Utils;

namespace Core.AspNetCore.Operations.Logic.SendMessage
{
    public class SendMessage : OperationAsync<SendMessageInDto, long?>
    {
        protected override async Task ExecutionAsync()
        {
            var apiClient = OperationFactory!.GetService<ApiClient>()
                            ?? throw Errors.InternalError("api_client_not_registered");
            var res = await apiClient.PostAsync<SendMessageInDto, OperationResult<long>>(
                Input,
                "Notify",
                "Message",
                "sendBackend");

            if (res?.Success == true)
                Output = res.Result;
            else
                Output = null;
        }
    }
}
