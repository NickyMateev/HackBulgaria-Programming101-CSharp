using System;
using Dynamic_Array;

namespace MapDataStructure
{
    public class Map <T, U>
    {
        DynamicArray<T> keys;
        DynamicArray<U> values;

        public void Add(T key, U value)
        {
            keys.Add(key);
            values.Add(value);
        }

        public bool ContainsKey(T key)
        {
            return keys.Contains(key);
        }

        public bool ContainsValue(U value)
        {
            return values.Contains(value);
        }

        public void Remove(T key)
        {
            values.RemoveAt(keys.IndexOf(key));     // removing the value of the pair also
            keys.Remove(key);
        }

        public void Clear()
        {
            keys.Clear();
            values.Clear();
        }

        public U this[T key]
        {
            get
            {
                if (keys.Contains(key))
                    return values[keys.IndexOf(key)];
                else
                    throw new ArgumentException("ERROR: Key doesn't exist!");
            }
            set
            {
                if (keys.Contains(key))
                    values[keys.IndexOf(key)] = value;
                else
                    keys.Add(key);
            }
        }

    }
}