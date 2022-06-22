using Flow.Operations.FormLeadLog.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadLog.Commands
{
    public class FormLeadLogUpdate : SaanaaDbUpdateAsync<FormLeadLogUpdateInDto>
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