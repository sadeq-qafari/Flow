using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Core.Common.Extensions
{
    public static class ObjectExtensions
    {

        //All of this methds in simple mode by ReflectValue Method 
        //See: TypeExtensions.ReflectValue

        public static void SetPropertyValue(this object obj, string propName, object value)
        {
            SetPropertyValue(obj, GetObjectProperty(obj, propName), value);
        }
        public static void SetPropertyValue(this object obj, PropertyInfo prop, object value)
        {
            prop.SetValue(obj, value);
        }
        public static object GetPropertyValue(this object obj, PropertyInfo prop)
        {
            return prop.GetValue(obj);
        }
        public static object GetPropertyValue(this object obj, string propName)
        {
            return GetObjectProperty(obj, propName).GetValue(obj);
        }

        public static PropertyInfo GetObjectProperty(object obj, string propName)
        {
            var prop = obj.GetType().GetProperty(propName);
            if (prop == null)
            {
                throw new Exception(string.Format("Property '{0}' does not found in object type '{1}'.", propName, obj.GetType().Name));
            }
            return prop;

        }
        public static IEnumerable<PropertyInfo> GetObjectProperties(this object obj, Func<PropertyInfo, bool> filter = null)
        {
            if (obj == null) return null;

            if (filter == null)
                filter = x => true;

            return obj.GetType().GetProperties().Where(filter);
        }
        public static Dictionary<string, object> ConvertToDictionary(this object obj, Func<PropertyInfo, bool> filter = null)
        {
            //If the object is a 'ExpandoObject' then convert it to the original one
            if (obj as IDictionary<string, object> != null)
            {
                return new Dictionary<string, object>(obj as IDictionary<string, object>);
            }

            var properties = obj.GetObjectProperties(filter);
            var result = new Dictionary<string, object>();

            //If object is null or it dosen't have any property returns an empty dictionary
            if (properties == null)
            {
                return result;
            }

            foreach (var item in properties)
            {
                result.Add(item.Name, item.GetValue(obj));
            }

            return result;
        }
        public static T GetAttribute<T>(this object obj, bool inherit = true)
            where T : Attribute
        {
            return obj.GetType().GetCustomAttribute<T>(inherit);
        }
        public static IEnumerable<T> GetAttributes<T>(this object obj, bool inherit = true)
           where T : Attribute
        {
            return obj.GetType().GetCustomAttributes<T>(inherit);
        }

        public static T Clone<T>(this object source)
        {
            var serialized = JsonSerializer.Serialize(source);
            return JsonSerializer.Deserialize<T>(serialized);
        }
    }
}
