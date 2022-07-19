using Core.Meteor;

namespace Flow.Operations.Element.Queries
{
    public class GetElement : DbSelectAsync<Element?>
    {
        public GetElement() : base("[Flow].[Element]")
        {
        }
    }
}