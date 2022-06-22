using Flow.Operations.FormLeadData.Dtos;
using Saanaa.Core.Meteor;

namespace Flow.Operations.FormLeadData.Commands
{
    public class FormLeadDataAdd : SaanaaDbInsertAsync<FormLeadDataAddInDto>
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

