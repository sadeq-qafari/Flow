using Core.Meteor;

namespace Flow.Operations.Form.Queries
{
    public class GetForm : DbSelectAsync<Form?>
    {
        public GetForm() : base("[Flow].[Form]")
        {
        }
    }
}