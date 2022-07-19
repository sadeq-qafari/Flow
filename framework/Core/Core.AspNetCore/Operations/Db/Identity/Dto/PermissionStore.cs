using System.Collections.Generic;
using System.Linq;
using Meteor.Utils;

namespace Core.AspNetCore.Operations.Db.Identity.Dto
{
    public class PermissionStore : Dictionary<string, Dictionary<string, List<string>>>
    {
        public PermissionStore()
        {
        }

        public PermissionStore(IEnumerable<string> permissions)
        {
            var dict = permissions.Select(item => item.ToLowerInvariant().Split('.'))
                .GroupBy(x => x[0])
                .ToDictionary(x => x.Key,
                    x => x.GroupBy(y => y[1])
                        .ToDictionary(y => y.Key,
                            y => y.Select(z => z[2]).Distinct().ToList()));

            foreach (var (key, value) in dict)
                Add(key, value);
        }

        public PermissionStore(string json)
        {
            var dict = json.FromJson<Dictionary<string, Dictionary<string, List<string>>>>();
            foreach (var (key, value) in dict)
                Add(key, value);
        }

        public bool HasPermission(string? permission)
        {
            var parts = permission?.ToLowerInvariant().Split('.');
            return parts?.Length switch
            {
                1 => this.ContainsKey(parts[0]),
                2 => this.GetValueOrDefault(parts[0])?.ContainsKey(parts[1]) == true,
                3 => this.GetValueOrDefault(parts[0])?.GetValueOrDefault(parts[1])?.Contains(parts[2]) == true,
                _ => false
            };
        }
    }
}
