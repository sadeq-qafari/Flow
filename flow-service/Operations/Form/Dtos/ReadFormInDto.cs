using Core.Meteor;

namespace Flow.Operations.Form.Dtos
{
    public class ReadFormInDto : IHaveTenant
    {
        public string? FormName { get; set; }
        public int Id { get; set; }
        public int? TenantId { get; set; }
    }
}
