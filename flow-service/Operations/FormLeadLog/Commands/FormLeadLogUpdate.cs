using Core.Meteor;
using Flow.Operations.FormLeadLog.Dtos;

namespace Flow.Operations.FormLeadLog.Commands
{
    public class FormLeadLogUpdate : DbUpdateAsync<FormLeadLogUpdateInDto>
    {
        public FormLeadLogUpdate() : base("[Flow].[FormLeadLog]",
            @"[FormLeadId]=@FormLeadId,
					[FormId]=@FormId,
					[ActionLookup]=@ActionLookup,
					[ActionName]=@ActionName,
					[Result]=@Result,
					[FormData]=@FormData")
        {
        }
    }
}