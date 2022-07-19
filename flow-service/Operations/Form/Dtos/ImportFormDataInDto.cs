using Core.Meteor;
using Microsoft.AspNetCore.Http;

namespace Flow.Operations.Form.Dtos
{
    public class ImportFormDataInDto : IHaveTenant, IHaveActionBy
    {
        public IFormFile? File { get; set; }
        public string FormName { get; set; }
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
    }

    public class FormDataModel
    {
        public string Guid { get; set; }
        public int FormPropertyId { get; set; }
        public string? Value { get; set; }
    }
}
