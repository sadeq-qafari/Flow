using Saanaa.Core.Meteor;

namespace Flow.Operations.Element.Queries
{
    public class GetElementAsDropDown : SaanaaDbQueryAsDropDown<Element>
    {
        public GetElementAsDropDown() : base("[Flow].[Element]")
        {
        }
    }
}
