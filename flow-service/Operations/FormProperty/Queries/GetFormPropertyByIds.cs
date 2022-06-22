using Saanaa.Core.Meteor;

namespace Flow.Operations.FormProperty.Queries
{
    public class GetFormPropertyByIds : SaanaaDbQueryByIds<FormProperty>
    {
        public GetFormPropertyByIds() : base("[Flow].[FormProperty]")
        {
        }
    }
}