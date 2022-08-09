using System.Collections.Generic;
using Core.Meteor;

namespace Flow.Operations.Form.Dtos;

public class BatchInsertInDto : IHaveActionBy, IHaveTenant
{
    public Dictionary<int, List<FormDataModel>> Data { get; set; }
    public int FormId { get; set; }
    public int ActionBy { get; set; }
    public int? TenantId { get; set; }
}