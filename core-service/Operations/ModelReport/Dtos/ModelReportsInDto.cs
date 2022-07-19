using Core.Meteor;

namespace Core.Operations.ModelReport.Dtos
{
    public class ModelReportsInDto : IHaveTenant
    {
        public string ServiceName { get; set; }
        public string ModelName { get; set; }
        public int? TenantId { get; set; }
    }
}
