using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA.Utilities
{
    public class MyKeyValuePair<TKey, TValue>
    {
        private TKey Key;
        private TValue Value;

        public MyKeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey GetKey()
        {
            return Key;
        }

        public TValue GetValue()
        {
            return Value;
        }
    }
}
