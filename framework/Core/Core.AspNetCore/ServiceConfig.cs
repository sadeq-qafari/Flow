using System.Collections.Generic;
using System.Linq;

namespace Core.AspNetCore
{
    public static class ServiceConfig
    {
        public static Dictionary<string, string> Configurations { get; } = new Dictionary<string, string>();
        public static string[] TrustedUrls { get; private set; } = new string[] { };

        public static void Add(IEnumerable<ServiceConfigItem> configurations)
        {
            foreach (var config in configurations)
                Configurations.Add(config.Key.ToLowerInvariant(), config.Value);
        }

        public static void SetTrustedUrls(IEnumerable<string> urls) =>
            TrustedUrls = urls.ToArray();

        public static void Add(string key, string value) =>
            Configurations.Add(key.ToLowerInvariant(), value);

        public static string Get(string key) =>
            Configurations[key.ToLowerInvariant()];
    }
}
