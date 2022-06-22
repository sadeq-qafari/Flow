using Saanaa.Core.Meteor;

namespace Flow.Operations.FormAction.Queries
{
    public class GetFormAction : SaanaaDbSelectAsync<FormAction?>
    {
        public GetFormAction() : base("[Flow].[FormAction]")
        {
        }
    }
}