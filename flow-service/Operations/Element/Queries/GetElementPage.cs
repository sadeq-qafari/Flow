using Core.Meteor;
using Flow.Operations.Element.Dtos;

namespace Flow.Operations.Element.Queries
{
    public class GetElementPage : DbQueryPage<ElementDto>
    {
        public GetElementPage() : base("[Flow].[Element]")
        {
        }
        
    }
}