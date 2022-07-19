using Core.Meteor;
using Meteor.Operation.Db.Default;
using NodaTime;

namespace Core.AspNetCore.Operations.Db.Log
{
    public class UserAgent : IDbModel<long>, IAmDbInsert
    {
        public long Id { get; set; }
        public string? Host { get; set; }
        public string? RemoteIpAddress { get; set; }
        public string? EndPoint { get; set; }
        public string? ServiceName { get; set; }
        public string? ModelName { get; set; }
        public int? EntityId { get; set; }
        public string? ActionName { get; set; }
        public string? UserDevice { get; set; }
        public string? UserOs { get; set; }
        public string? UserBrowser { get; set; }
        public string? UserBrowserVersion { get; set; }
        public int CreatedBy { get; set; }
        public Instant CreatedAt { get; set; }
        public int? TenantId { get; set; }
    }
}
