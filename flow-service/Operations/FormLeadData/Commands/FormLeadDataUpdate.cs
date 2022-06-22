using Flow.Operations.FormLeadData.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadData.Commands
{
    public class FormLeadDataUpdate : SaanaaDbUpdateAsync<FormLeadDataUpdateInDto>
    {
        public FormLeadDataUpdate() : base("[Flow].[FormLeadData]",
            @"[FormLeadId]=@FormLeadId,
					[FormPropertyId]=@FormPropertyId,
					[Value]=@Value")
        {
        }
    }
}