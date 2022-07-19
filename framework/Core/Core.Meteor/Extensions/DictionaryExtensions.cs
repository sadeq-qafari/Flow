using System;
using System.Collections.Generic;
using System.Reflection;

namespace Core.Meteor.Extensions
{
    public static class DictionaryExtensions
    {
        public static TObject GetObject<TObject>(this IDictionary<string, object> d)
        {
            PropertyInfo[] props = typeof(TObject).GetProperties();
            TObject res = Activator.CreateInstance<TObject>();
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].CanWrite && d.ContainsKey(props[i].Name))
                {
                    props[i].SetValue(res, d[props[i].Name], null);
                }
            }

            return res;
        }
    }
}
