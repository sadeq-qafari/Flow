using Core.Meteor;
using Flow.Operations.FormLeadLog.Dtos;

namespace Flow.Operations.FormLeadLog.Commands
{
    public class FormLeadLogAdd : DbInsertAsync<FormLeadLogAddInDto>
    {
        public FormLeadLogAdd() : base("[Flow].[FormLeadLog]",
            @"[FormLeadId],
						[FormId],
						[ActionLookup],
						[ActionName],
						[Result],
						[FormData]",
            @"@FormLeadId,
						@FormId,
						@ActionLookup,
						@ActionName,
						@Result,
						@FormData")
        {
        }
    }
}

