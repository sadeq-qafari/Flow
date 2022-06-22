using Flow.Operations.Form.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Form.Commands
{
    public class FormUpdate : SaanaaDbUpdateAsync<FormUpdateInDto>
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