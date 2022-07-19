using System;
using System.Reflection;
using System.Text;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Core.Meteor
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnorePersianNormalizationAttribute : Attribute
    {
    }

    public static class PersianText
    {
        public static void NormalizeObject(object o)
        {
            var type = o.GetType();
            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.PropertyType == typeof(string) && prop.CanWrite &&
                    !prop.HasAttribute<IgnorePersianNormalizationAttribute>())
                    prop.SetValue(o, ArabicToPersian(prop.GetValue(o) as string));
            }
        }

        public static string? ArabicToPersian(string? s) =>
            ArabicToPersianNumber(ArabicToPersianText(s))?.Trim();

        public static string? ArabicToPersianText(string? s)
        {
            if (s == null)
                return null;

            var builder = new StringBuilder(s.Length);
            const string arabicChars = "ىيٸیؤوٶةهۀہۂۃەكک";
            const string persianChars = "ییییوووهههههههکک";

            foreach (var c in s)
            {
                var index = arabicChars.IndexOf(c);
                builder.Append(index >= 0 ? persianChars[index] : c);
            }

            return builder.ToString();
        }

        public static string? ArabicToPersianNumber(string? s)
        {
            if (s == null)
                return null;

            var builder = new StringBuilder(s.Length);
            const string arabicNumbers = "٠١٢٣٤٥٦٧٨٩";
            const string persianNumbers = "٠١٢٣۴۵۶٧٨٩";

            foreach (var c in s)
            {
                var index = arabicNumbers.IndexOf(c);
                builder.Append(index >= 0 ? persianNumbers[index] : c);
            }

            return builder.ToString();
        }

        public static string? EnglishToPersianNumber(string? s)
        {
            if (s == null)
                return null;

            var builder = new StringBuilder(s.Length);
            const string englishNumbers = "0123456789";
            const string persianNumbers = "٠١٢٣۴۵۶٧٨٩";

            foreach (var c in s)
            {
                var index = englishNumbers.IndexOf(c);
                builder.Append(index >= 0 ? persianNumbers[index] : c);
            }

            return builder.ToString();
        }

        public static string? PersianToEnglishNumber(string? s)
        {
            if (s == null)
                return null;

            var builder = new StringBuilder(s.Length);
            const string englishNumbers = "0123456789";
            const string persianNumbers = "٠١٢٣۴۵۶٧٨٩";

            foreach (var c in s)
            {
                var index = persianNumbers.IndexOf(c);
                builder.Append(index >= 0 ? englishNumbers[index] : c);
            }

            return builder.ToString();
        }
        public static string? ArabicToEnglishNumber(string? s)
        {
            if (s == null)
                return null;

            var builder = new StringBuilder(s.Length);
            const string englishNumbers = "0123456789";
            const string arabicNumbers = "٠١٢٣٤٥٦٧٨٩";

            foreach (var c in s)
            {
                var index = arabicNumbers.IndexOf(c);
                builder.Append(index >= 0 ? englishNumbers[index] : c);
            }

            return builder.ToString();
        }
    }
}
