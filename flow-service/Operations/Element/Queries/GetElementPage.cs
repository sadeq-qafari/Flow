using Flow.Operations.Element.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Element.Queries
{
    public class GetElementPage : SaanaaDbQueryPage<ElementDto>
    {
        public GetElementPage() : base("[Flow].[Element]")
        {
        }
        
    }
}