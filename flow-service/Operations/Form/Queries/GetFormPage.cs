using Flow.Operations.Form.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Form.Queries
{
    public class GetFormPage : SaanaaDbQueryPage<FormDto>
    {
        public GetFormPage() : base("[Flow].[Form]")
        {
        }
        
    }
}