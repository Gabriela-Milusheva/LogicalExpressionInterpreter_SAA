using System;
using System.Text;
using System.Threading.Tasks;

namespace SAA.Utilities
{
    public class MyStack<T>
    {
        private MyList<T> list;

        public MyStack(int length)
        {
            list = new MyList<T>(length); 
        }

        public void Push(T item)
        {
            list.Add(item);
        }

        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T poppedItem = list.GetElementAt(list.Count - 1);
           list.RemoveAt(list.Count - 1);

            return poppedItem;
        }

        public int Count
        {
            get { return list.Count; }
        }

        public T GetLastElement()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return list.GetElementAt(list.Count - 1);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }
    }
}
