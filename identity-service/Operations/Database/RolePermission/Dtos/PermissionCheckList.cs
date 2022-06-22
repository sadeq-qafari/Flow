using System.Collections.Generic;
using System.Linq;

namespace Identity.Operations.Database.RolePermission.Dtos
{
    public class PermissionCheckList : Dictionary<string, Dictionary<string, Dictionary<string, bool>>>
    {
        public PermissionCheckList()
        {
        }
        public PermissionCheckList(IEnumerable<string> permissions, IEnumerable<string> rolePermissions)
        {
            var dict = permissions.Select(item => item.ToLowerInvariant().Split('.'))
                .GroupBy(x => x[0])
                .ToDictionary(x => x.Key,
                    x => x.GroupBy(y => y[1])
                        .ToDictionary(y => y.Key,
                            y => y.ToDictionary(z => z[2], z =>
                                rolePermissions.Any(p => p.ToLowerInvariant() == string.Join('.',z)))));

            foreach (var (key, value) in dict)
                Add(key, value);
        }
    }
}
