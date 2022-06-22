using Saanaa.Core.Meteor;

namespace Flow.Operations.FormAction.Queries
{
    public class GetFormActionAsDropDown : SaanaaDbQueryAsDropDown<FormAction>
    {
        public GetFormActionAsDropDown() : base("[Flow].[FormAction]")
        {
        }
    }
}
