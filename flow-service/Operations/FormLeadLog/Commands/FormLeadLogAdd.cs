using Flow.Operations.FormLeadLog.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadLog.Commands
{
    public class FormLeadLogAdd : SaanaaDbInsertAsync<FormLeadLogAddInDto>
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

