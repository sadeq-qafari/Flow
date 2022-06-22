namespace Core
{
    public static class Extensions
    {
        public static string? MakeFirstLetterUpper(this string? str) =>
            string.IsNullOrWhiteSpace(str)
                ? str
                : str.Substring(0, 1).ToUpperInvariant() + str.Substring(1);
    }
}
