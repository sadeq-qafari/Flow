using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Core.Meteor.Extensions
{
    public static class EnumerableExtensions
    {
        private static readonly MethodInfo CastMethod = typeof(Enumerable).GetMethod("Cast")!;
        private static readonly MethodInfo ToListMethod = typeof(Enumerable).GetMethod("ToList")!;

        public static object? CastAndList(this IEnumerable items, Type targetType)
        {
            var castItems = CastMethod.MakeGenericMethod(new Type[] { targetType })
                .Invoke(null, new object[] { items });
            var list = ToListMethod.MakeGenericMethod(new Type[] { targetType })
                .Invoke(null, new object[] { castItems! });

            return list;
        }

        public static DataTable AsDataTable<T>(this IEnumerable<T> items, string udtName, Func<T, object> props)
        {
            var dataTable = new DataTable(udtName);
            PropertyInfo?[] properties = typeof(T).GetProperties();
            var propsObject = props(Activator.CreateInstance<T>());
            var propNames = propsObject.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance)
                .Select(x => x.Name);
            properties = propNames
                .Select(x => properties.FirstOrDefault(y => y.Name == x))
                .Where(x => x != null)
                .ToArray();

            dataTable.Columns.AddRange(properties
                .Select(p =>
                {
                    var type = p.PropertyType.IsEnum ? Enum.GetUnderlyingType(p.PropertyType) : p.PropertyType;
                    var underlyingType = Nullable.GetUnderlyingType(type);
                    var isNullable = underlyingType != null;
                    if (isNullable)
                        type = underlyingType;

                    return new DataColumn(p.Name, type!)
                    {
                        AllowDBNull = isNullable || type == typeof(string)
                    };
                })
                .ToArray());

            foreach (var item in items)
            {
                var row = dataTable.NewRow();

                foreach (var prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
