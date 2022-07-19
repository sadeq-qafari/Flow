using System.Threading.Tasks;
using Core.Meteor;
using Meteor.Operation;
using Meteor.Utils;

namespace Core.AspNetCore.Operations.Db.Log.Commands
{
    public class LogUserAgent : OperationAsync<UserAgent, bool>
    {
        private ApiClient? _apiClient;

        protected override Task PrepareExecutionAsync()
        {
            _apiClient = OperationFactory!.GetService<ApiClient>() ??
                         throw Errors.InvalidInput("ApiClient_not_registered");;

            return Task.CompletedTask;
        }

        protected override async Task ExecutionAsync()
        {
            var result = await _apiClient!.PostAsync<UserAgent, OperationResult<long>>(Input, "Log", "UserAgent");
            Output = result != null && result.Success && result.Result > 0;
        }
    }
}
