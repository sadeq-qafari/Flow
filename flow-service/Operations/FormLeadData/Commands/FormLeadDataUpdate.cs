using Core.Meteor;
using Flow.Operations.FormLeadData.Dtos;

namespace Flow.Operations.FormLeadData.Commands
{
    public class FormLeadDataUpdate : DbUpdateAsync<FormLeadDataUpdateInDto>
    {
        public FormLeadDataUpdate() : base("[Flow].[FormLeadData]",
            @"[FormLeadId]=@FormLeadId,
					[FormPropertyId]=@FormPropertyId,
					[Value]=@Value")
        {
        }
    }
}