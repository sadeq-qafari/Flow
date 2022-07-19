using System.Collections.Generic;
using System.Reflection;

namespace Core.Meteor.Extensions
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, object?> GetDictionary<TObject>(this TObject o)
        {
            IDictionary<string, object?> res = new Dictionary<string, object?>();
            PropertyInfo[] props = typeof(TObject).GetProperties();
            foreach (var prop in props)
            {
                if (prop.CanRead && !res.ContainsKey(prop.Name))
                {
                    res.Add(prop.Name, prop.GetValue(o, null));
                }
            }
            return res;
        }
    }
}
