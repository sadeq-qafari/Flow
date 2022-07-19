using Core.Meteor;
using Flow.Operations.FormLeadData.Dtos;

namespace Flow.Operations.FormLeadData.Commands
{
    public class FormLeadDataAdd : DbInsertAsync<FormLeadDataAddInDto>
    {
        public FormLeadDataAdd() : base("[Flow].[FormLeadData]",
            @"[FormLeadId],
						[FormPropertyId],
						[Value]",
            @"@FormLeadId,
						@FormPropertyId,
						@Value")
        {
        }
    }
}

