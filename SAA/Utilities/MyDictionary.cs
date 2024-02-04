using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace SAA.Utilities
{
    public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private MyList<KeyValuePair<TKey, TValue>> items;

        public MyDictionary(int capacity)
        {
            items = new MyList<KeyValuePair<TKey, TValue>>(capacity);
        }
        public void Add(TKey key, TValue value)
        {
            items.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool ContainsKey(TKey key)
        {
            foreach (var item in items)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

      
        public bool TryGetValue(TKey key, out TValue value)
        {
            foreach (var item in items)
            {
                if (item.Key.Equals(key))
                {
                    value = item.Value;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }
     


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
