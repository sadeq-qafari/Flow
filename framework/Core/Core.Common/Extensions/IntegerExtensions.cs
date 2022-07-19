using System.Collections.Generic;
using System.Security.Cryptography;

namespace Core.Common.Extensions
{
    /// <summary>
    ///     Provides extension methods to the <see cref="int">System.int</see> object.
    /// </summary>
    public static class IntegerExtensions
    {
        private static RandomNumberGenerator rand = System.Security.Cryptography.RandomNumberGenerator.Create();

        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        public static int Increment(this int i)
        {
            return ++i;
        }

        public static int Decrement(this int i)
        {
            return --i;
        }

        public static bool isRandomSecure(this int source)
        {
            var data = new byte[4];
            rand.GetBytes(data);

            return source == ((data[0] << 24) | (data[1] << 16) | (data[2] << 8) | data[3]);
        }

        public static bool IsBetween(this int value, int start, int end)
        {
            return Comparer<int>.Default.Compare(value, start) >= 0 && Comparer<int>.Default.Compare(value, end) <= 0;
        }
    }
}