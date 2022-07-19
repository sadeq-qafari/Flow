using Core.Meteor;

namespace Flow.Operations.Form.Queries
{
    public class GetFormAsDropDown : DbQueryAsDropDown<Form>
    {
        public GetFormAsDropDown() : base("[Flow].[Form]")
        {
        }
    }
}
