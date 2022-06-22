using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLead.Queries
{
    public class GetFormLead : SaanaaDbSelectAsync<FormLead?>
    {
        public GetFormLead() : base("[Flow].[FormLead]")
        {
        }
    }
}