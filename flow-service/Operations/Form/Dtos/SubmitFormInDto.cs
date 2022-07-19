using System.Collections.Generic;
using Core.Meteor;

namespace Flow.Operations.Form.Dtos
{
    public class SubmitFormInDto : IHaveActionBy,IHaveTenant
    {
        public string? FormName { get; set; }
        public int? Id { get; set; }
        public Dictionary<string,object?> Data { get; set; }
        public bool CheckForDuplicate { get; set; } = false;
        public int ActionBy { get; set; }
        public int? TenantId { get; set; }
    }

    public class SubmitFormData
    {
        public int FormPropertyId { get; set; }
        public string? Value { get; set; }
    }
}
