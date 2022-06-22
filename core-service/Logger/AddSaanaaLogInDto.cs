using System;
using Serilog.Events;

namespace Saanaa.Core.Logger
{
    public class AddSaanaaLogInDto
    {
        public string? Service { get; set; }
        public string? TableName { get; set; }
        public int? UserId { get; set; }
        public long? EntityId { get; set; }
        public int? TenantId { get; set; }
        public string? Type { get; set; }
        public string? Message { get; set; }
        public string? MessageTemplate { get; set; }
        public LogEventLevel Level { get; set; }
        public string? Exception { get; set; }
        public string? Properties { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
