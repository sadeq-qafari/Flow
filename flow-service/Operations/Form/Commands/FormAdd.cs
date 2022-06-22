using Flow.Operations.Form.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Form.Commands
{
    public class FormAdd : SaanaaDbInsertAsync<FormAddInDto>
    {
        public FormAdd() : base("[Flow].[Form]",
            @"[Name],
						[Title],
						[Description],
						[Layout],
						[IsAddable],
						[IsUpdatable],
						[IsDeletable]",
            @"@Name,
						@Title,
						@Description,
						@Layout,
						@IsAddable,
						@IsUpdatable,
						@IsDeletable")
        {
        }
    }
}

