using Saanaa.Core.Meteor;

namespace Flow.Operations.FormPermission.Queries
{
    public class GetFormPermission : SaanaaDbSelectAsync<FormPermission?>
    {
        public GetFormPermission() : base("[Flow].[FormPermission]")
        {
        }
    }
}