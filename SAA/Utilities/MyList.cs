using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace SAA.Utilities
{
    public class MyList<T> : IEnumerable<T>
    {
        public T[] array;
        private int count;

        public MyList(int length)
        {
            array = new T[length];
            count = 0;
        }

        public void Add(T item)
        {
            if (count == array.Length)
            {
                ResizeArray();
            }

            array[count] = item;
            count++;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
        public T GetElementAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            return array[index];
        }

        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            count = 0;

            Array.Clear(array, 0, array.Length);
        }
        public bool Contains(T item)
        {
            return array.Take(count).Contains(item);
        }
        private void ResizeArray()
        {
            int newCapacity = array.Length * 2;
            Array.Resize(ref array, newCapacity);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            count--;
        }
        public void Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                return array[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                array[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (AreEqual(array[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        private bool AreEqual(T x, T y)
        {
            if (x is string && y is string)
            {
                string strX = (string)(object)x;
                string strY = (string)(object)y;
            }


            return object.Equals(x, y); 
        }

    }
}
