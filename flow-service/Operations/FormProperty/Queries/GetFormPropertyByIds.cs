using Core.Meteor;

namespace Flow.Operations.FormProperty.Queries
{
    public class GetFormPropertyByIds : DbQueryByIds<FormProperty>
    {
        public GetFormPropertyByIds() : base("[Flow].[FormProperty]")
        {
        }
    }
}