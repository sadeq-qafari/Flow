using Core.Meteor;

namespace Flow.Operations.Element.Queries
{
    public class GetElementByIds : DbQueryByIds<Element>
    {
        public GetElementByIds() : base("[Flow].[Element]")
        {
        }
    }
}