using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAA.Function;

namespace SAA.Utilities
{
    public class MyHashTable<TKey, TValue>
    {
        private int Capacity;
        public MyList<MyKeyValuePair<TKey, TValue>> table;

        public MyHashTable(int capacity)
        {
            table = new MyList<MyKeyValuePair<TKey, TValue>>(capacity);

        }

        public void Add(TKey key, TValue value)
        {
            table.Add(new MyKeyValuePair<TKey, TValue>(key, value));
        }

        public bool ContainsKey(TKey key)
        {
            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].GetKey().Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public TValue? GetValue(TKey key)
        {
            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].GetKey().Equals(key))
                {
                    return table[i].GetValue();
                }
            }

            throw new Exception("Dictionary doesn't contain key");
        }

        public bool TryGetValue(TKey key, out TValue? value)
        {
            value = default;

            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].GetKey().Equals(key))
                {
                    value = table[i].GetValue();
                    return true;
                }
            }

            return false;
        }


        public MyKeyValuePair<TKey, TValue>? GetFunction(string functionName)
        {
            foreach (var functionPair in table)
            {
                if (functionPair.GetKey()?.ToString() == functionName)
                {
                    //return (DefinedFunction)(object)functionPair.GetValue();
                    return functionPair;
                }
            }

            return null;
        }
    }
}