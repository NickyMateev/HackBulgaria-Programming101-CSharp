using System.Collections.Generic;

namespace Generic_Dequeue
{
    public class GenericDequeue<T>
    {
        private List<T> list = null;

        public GenericDequeue()
        {
            list = new List<T>();
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T obj)
        {
            foreach (var item in list)
            {
                if (item.Equals(obj))
                    return true;
            }
            return false;
        }

        public T RemoveFromFront()
        {
            T firstElem = list[0];
            list.RemoveAt(0);
            return firstElem;
        }

        public T RemoveFromEnd()
        {
            T lastElem = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return lastElem;
        }

        public void AddToFront(T obj)
        {
            list.Insert(0, obj);
        }

        public void AddToEnd(T obj)
        {
            list.Add(obj);
        }

        public T PeekFromFront()
        {
            return list[0];
        }

        public T PeekFromEnd()
        {
            return list[list.Count - 1];
        }
    }
}