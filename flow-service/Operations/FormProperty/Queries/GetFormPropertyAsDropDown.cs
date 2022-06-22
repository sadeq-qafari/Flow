using Saanaa.Core.Meteor;

namespace Flow.Operations.FormProperty.Queries
{
    public class GetFormPropertyAsDropDown : SaanaaDbQueryAsDropDown<FormProperty>
    {
        public GetFormPropertyAsDropDown() : base("[Flow].[FormProperty]")
        {
        }
    }
}
