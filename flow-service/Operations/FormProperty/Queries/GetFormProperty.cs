using Core.Meteor;

namespace Flow.Operations.FormProperty.Queries
{
    public class GetFormProperty : DbSelectAsync<FormProperty?>
    {
        public GetFormProperty() : base("[Flow].[FormProperty]")
        {
        }
    }
}