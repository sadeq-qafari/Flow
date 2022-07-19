using Core.Meteor;

namespace Flow.Operations.Element.Queries
{
    public class GetElementAsDropDown : DbQueryAsDropDown<Element>
    {
        public GetElementAsDropDown() : base("[Flow].[Element]")
        {
        }
    }
}
