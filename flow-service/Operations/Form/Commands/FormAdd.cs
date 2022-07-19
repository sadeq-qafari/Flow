using Core.Meteor;
using Flow.Operations.Form.Dtos;

namespace Flow.Operations.Form.Commands
{
    public class FormAdd : DbInsertAsync<FormAddInDto>
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

