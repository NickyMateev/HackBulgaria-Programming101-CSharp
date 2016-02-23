namespace Generic_Stack
{
    public class GenericStack<T>
    {
        private T[] stack;
        private int counter;
        private int capacity;

        public GenericStack()
        {
            counter = -1;
            capacity = 4;
            stack = new T[capacity];
        }

        public T Peek()
        {
            return stack[counter];
        }

        public T Pop()
        {
            T topElement = stack[counter];
            counter--;
            return topElement;
        }

        public void Push(T obj)
        {
            counter++;
            if (counter == capacity)
            {
                capacity *= 2;
                T[] newStack = new T[capacity];
                for (int i = 0; i < stack.Length; i++)
                {
                    newStack[i] = stack[i];
                }
                newStack[counter] = obj;
                stack = newStack;
            }
            else
                stack[counter] = obj;
        }

        public void Clear()
        {
            counter = -1;
        }

        public bool Contains(T obj)
        {
            for (int i = 0; i <= counter; i++)
            {
                if (stack[i].Equals(obj))
                    return true;
            }
            return false;
        }
    }
}