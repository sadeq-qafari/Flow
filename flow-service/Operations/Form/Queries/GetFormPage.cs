using Core.Meteor;
using Flow.Operations.Form.Dtos;

namespace Flow.Operations.Form.Queries
{
    public class GetFormPage : DbQueryPage<FormDto>
    {
        public GetFormPage() : base("[Flow].[Form]")
        {
        }
        
    }
}