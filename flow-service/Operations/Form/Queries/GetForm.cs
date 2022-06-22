using Saanaa.Core.Meteor;

namespace Flow.Operations.Form.Queries
{
    public class GetForm : SaanaaDbSelectAsync<Form?>
    {
        public GetForm() : base("[Flow].[Form]")
        {
        }
    }
}