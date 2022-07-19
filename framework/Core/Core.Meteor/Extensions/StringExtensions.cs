namespace Core.Meteor.Extensions
{
    public static class StringExtensions
    {
        public static (string?, string?) TryExtractServiceModelName(this string tableName)
        {
            if (!tableName.Contains('.'))
                return (null, null);
            var parts = tableName.Split('.');
            if (parts.Length != 2)
                return (null, null);

            var service = parts[0].Replace("[", "").Replace("]", "");
            var model = parts[1].Replace("[", "").Replace("]", "");
            return (service, model);
        }
    }
}
