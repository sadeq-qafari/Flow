using System.Collections.Generic;
using System.Linq;

namespace Core.Common.Helpers
{
    public class KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    public class KeyValueList<TKey, TValue> : List<KeyValue<TKey, TValue>>
    {
        public TValue this[TKey key] => GetValue(key);

        public TValue GetValue(TKey key) =>
            this.First(x => x.Key.Equals(key)).Value;
    }
}
