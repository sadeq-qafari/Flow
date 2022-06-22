using Saanaa.Core.Meteor;

namespace Flow.Operations.Form.Queries
{
    public class GetFormAsDropDown : SaanaaDbQueryAsDropDown<Form>
    {
        public GetFormAsDropDown() : base("[Flow].[Form]")
        {
        }
    }
}
