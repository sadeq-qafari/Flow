using Core.Meteor;
using Flow.Operations.Form.Dtos;

namespace Flow.Operations.Form.Commands
{
    public class FormUpdate : DbUpdateAsync<FormUpdateInDto>
    {
        public FormUpdate() : base("[Flow].[Form]",
            @"[Name]=@Name,
					[Title]=@Title,
					[Description]=@Description,
					[Layout]=@Layout,
					[IsAddable]=@IsAddable,
					[IsUpdatable]=@IsUpdatable,
					[IsDeletable]=@IsDeletable")
        {
        }
    }
}