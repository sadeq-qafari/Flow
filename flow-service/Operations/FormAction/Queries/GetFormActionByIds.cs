using Saanaa.Core.Meteor;

namespace Flow.Operations.FormAction.Queries
{
    public class GetFormActionByIds : SaanaaDbQueryByIds<FormAction>
    {
        public GetFormActionByIds() : base("[Flow].[FormAction]")
        {
        }
    }
}