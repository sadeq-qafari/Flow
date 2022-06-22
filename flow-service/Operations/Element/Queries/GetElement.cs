using Saanaa.Core.Meteor;

namespace Flow.Operations.Element.Queries
{
    public class GetElement : SaanaaDbSelectAsync<Element?>
    {
        public GetElement() : base("[Flow].[Element]")
        {
        }
    }
}