using System;

namespace Dynamic_Array
{
    public class DynamicArray<T>
    {
        private T[] array;
        private int capacity;
        private int count = 0;

        public DynamicArray()
        {
            capacity = 10;
            array = new T[capacity];
        }
        
        public DynamicArray(int capacity)
        {
            this.capacity = capacity;
            array = new T[capacity];
        }

        public int Capacity { get { return capacity; } private set { capacity = value; } }
        public int Count { get { return count; } private set { count = value; } }

        public bool Contains(T value)
        {
            foreach (var element in array)
            {
                if (element.Equals(value))
                    return true;
            }
            return false;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(value))
                    return i;
            }
            return -1;
        }

        private void Resize()
        {
            T[] newArray;
            if (Count <= Capacity / 3)
            {
                Capacity /= 2;
                newArray = new T[Capacity];
            }
            else if (Capacity <= 2048)
            {
                Capacity *= 2;
                newArray = new T[Capacity];
            }
            else  // Capacity > 2048
            {
                Capacity += 256;
                newArray = new T[Capacity];
            }
                
            for (int i = 0; i < Count; i++)
                newArray[i] = array[i];

            array = newArray;
        }

        public void Add(T value)
        {
            if (Count == Capacity)
                Resize();

            array[Count] = value;
            Count++;
        }

        public void InsertAt(int index, T value)
        {
            if (index <= Count)
            {
                if (Count == Capacity)
                    Resize();

                if (index == Count)
                    array[Count] = value;
                else
                {
                    for (int i = Count; i > index; i--)
                        array[i] = array[i - 1];

                    array[index] = value;
                }
                Count++;
            }
            else
                throw new ArgumentException("ERROR: Invalid index!");
        }

        public void Remove(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(value))
                {
                    for (int j = i; j < Count - 1; j++)
                        array[j] = array[j + 1];

                    array[Count - 1] = default(T);
                    Count--;
                }
            }

            if (Count <= Capacity / 3)
                Resize();
        }

        public void RemoveAt(int index)
        {
            if (index < Count)
            {
                if (index == Count - 1)
                    array[Count - 1] = default(T);
                else
                {
                    for (int i = index; i < Count - 1; i++)
                        array[i] = array[i + 1];

                    array[Count - 1] = default(T);
                }

                Count--;
            }
            else
                throw new ArgumentException("ERROR: Invalid index!");

            if (Count <= Capacity / 3)
                Resize();
        }

        public void Clear()
        {
            Count = 0;
            Capacity = 10;
            array = new T[Capacity];
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public T[] ToArray()
        {
            T[] newArray = new T[Count];
            for (int i = 0; i < Count; i++)
                newArray[i] = array[i];

            return newArray;
        }
    }
}