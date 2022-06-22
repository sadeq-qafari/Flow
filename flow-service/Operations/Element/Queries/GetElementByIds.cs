using Saanaa.Core.Meteor;

namespace Flow.Operations.Element.Queries
{
    public class GetElementByIds : SaanaaDbQueryByIds<Element>
    {
        public GetElementByIds() : base("[Flow].[Element]")
        {
        }
    }
}