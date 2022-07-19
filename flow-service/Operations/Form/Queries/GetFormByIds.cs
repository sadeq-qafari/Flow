using Core.Meteor;

namespace Flow.Operations.Form.Queries
{
    public class GetFormByIds : DbQueryByIds<Form>
    {
        public GetFormByIds() : base("[Flow].[Form]")
        {
        }
    }
}