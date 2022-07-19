namespace Core.AspNetCore.Security
{
    public class SecurityOptions
    {
        public string IdentityApiUrl { get; set; }
        
        public string MongoConnectionString { get; set; }
        
        public string RedisConnectionString { get; set; }
    }
}
