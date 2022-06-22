using Saanaa.Core.Meteor;

namespace Flow.Operations.Form.Queries
{
    public class GetFormByIds : SaanaaDbQueryByIds<Form>
    {
        public GetFormByIds() : base("[Flow].[Form]")
        {
        }
    }
}