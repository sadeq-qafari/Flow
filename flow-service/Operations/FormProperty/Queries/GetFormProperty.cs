using Saanaa.Core.Meteor;

namespace Flow.Operations.FormProperty.Queries
{
    public class GetFormProperty : SaanaaDbSelectAsync<FormProperty?>
    {
        public GetFormProperty() : base("[Flow].[FormProperty]")
        {
        }
    }
}