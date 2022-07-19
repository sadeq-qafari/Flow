using System;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Core.AspNetCore.Redis
{
    public class RedisCache
    {
        public StackExchange.Redis.IDatabase Db { get; }

        public RedisCache(string connectionString)
        {
            var redis = ConnectionMultiplexer.Connect(connectionString);
            Db = redis.GetDatabase();
        }

        public Task<bool> Exists(string key) =>
            Db.KeyExistsAsync(key);

        public Task<bool> Set(string key, object value, TimeSpan? expiry = null) =>
            Db.StringSetAsync(key, JsonSerializer.Serialize(value), expiry);

        public Task<bool> Set(string key, string value, TimeSpan? expiry = null) =>
            Db.StringSetAsync(key, value, expiry);

        public async Task<T> Get<T>(string key)
        {
            var json = await Db.StringGetAsync(key);

            return json.HasValue && !string.IsNullOrWhiteSpace(json)
                ? JsonSerializer.Deserialize<T>(json)
                : default;
        }

        public async Task<RedisValue> Get(string key) =>
            await Db.StringGetAsync(key);


        public static class Keys
        {
            public static string TenantInfo(string tenantUrl) => $"base:tnt:info:{tenantUrl}";
            public static string UserPermissionList(int? tenantId, int? branchId, int userId) =>
                $"base:user:prm:{tenantId ?? 0}:{branchId ?? 0}:{userId}";
        }
    }
}
