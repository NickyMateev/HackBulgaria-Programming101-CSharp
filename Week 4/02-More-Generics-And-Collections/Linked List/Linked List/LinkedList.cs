using System;
using System.Collections;

namespace Linked_List
{
    public class LinkedList<T> : IEnumerator, IEnumerable
    {
        private Node headNode;
        private int position = -1;

        private class Node
        {
            private T value;
            private Node nextNode;
            
            public T Value { get { return value; } set { this.value = value; } }
            public Node Next { get { return nextNode; } set { nextNode = value; } }
            
        }

        public int Count { get; private set; } = 0;

        public object Current   // IEnumerator
        {
            get
            {
                return this[position];
            }
        }

        public void Add(T value)
        {
            if (headNode == null)
            {
                headNode = new Node();
                headNode.Value = value;
            }
            else
            {
                Node current = headNode;
                while(current.Next != null)
                {
                    current = current.Next;
                }

                Node newNode = new Node();
                newNode.Value = value;
                current.Next = newNode;
            }
            Count++;
        }

        public void InsertAfter(T key, T value)
        {
            Node current = headNode;
            while(current != null && !current.Value.Equals(key))        // current.Equals or current.Value.Equals?
            {
                current = current.Next;
            }

            if (current != null)
            {
                Node newNode = new Node();
                newNode.Value = value;

                Node tempNode = current.Next;
                current.Next = newNode;
                newNode.Next = tempNode;
            }
            else
                throw new ArgumentException("There's no such key.");

            Count++;
        }
        
        public void InsertBefore(T key, T value)
        {
            Node current = headNode;
            while(current != null && current.Next != null && !current.Next.Value.Equals(key))
            {
                current = current.Next;
            }

            if (current != null || current.Next != null)
            {
                Node newNode = new Node();
                newNode.Value = value;

                Node tempNode = current.Next;
                current.Next = newNode;
                newNode.Next = tempNode;
            }
            else if (headNode.Value.Equals(key))    // this is the case when there is only one node in the LinkedList
            {
                Node newNode = new Node();
                newNode.Value = value;

                Node tempNode = headNode;
                headNode = newNode;
                newNode.Next = tempNode;
            }
            else
                throw new ArgumentException("There's no such key.");

            Count++;
        }

        public void InsertAt(int index, T value)
        {
            Node curNode = headNode;
            int curIndex = 0;

            if (index == 0)
            {
                if (headNode != null)
                {
                    Node newNode = new Node();
                    newNode.Value = value;

                    Node tempNode = headNode;
                    headNode = newNode;
                    headNode.Next = tempNode;
                }
                else
                {
                    Node newNode = new Node();
                    newNode.Value = value;
                    headNode = newNode;
                }
            }
            else
            {
                while (curIndex != index - 1)
                {
                    curNode = curNode.Next;
                    curIndex++;

                    if (curNode.Next == null && curIndex != index - 1)
                        throw new IndexOutOfRangeException("ERROR: Invalid index!");
                }

                Node newNode = new Node();
                newNode.Value = value;

                if (curNode.Next == null)
                    curNode.Next = newNode;
                else
                {
                    Node tempNode = curNode.Next;
                    curNode.Next = newNode;
                    newNode.Next = tempNode;
                }

            }

            Count++;
        }

        public void Remove(T value)
        {
            if (headNode == null)
                throw new ArgumentException("ERROR: Cannot remove a value from an empty LinkedList!");
            else if (headNode.Value.Equals(value))
                headNode = headNode.Next;
            else
            {
                Node curNode = headNode;
                while (curNode.Next != null && !curNode.Next.Value.Equals(value))
                    curNode = curNode.Next;

                if (curNode.Next != null)
                    curNode.Next = curNode.Next.Next;
                else
                    throw new ArgumentException("ERROR: Value doesn't exist in the LinkedList!");
                
            }

            Count--;
        }

        public void RemoveAt(int index)
        {
            if (headNode == null)
                throw new ArgumentException("ERROR: Cannot remove an element from an empty LinkedList!");
            else if (index == 0)
                headNode = headNode.Next;
            else
            {
                Node curNode = headNode;
                int curIndex = 0;
                while(curNode.Next != null && curIndex != index - 1)
                {
                    curNode = curNode.Next;
                    curIndex++;
                }

                if (curNode.Next != null)
                    curNode.Next = curNode.Next.Next;
                else
                    throw new ArgumentException("ERROR: Invalid index!");   
            }

            Count--;
        }

        public void Clear()
        {
            headNode = null;
            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                Node curNode = headNode;
                int curIndex = 0;

                if (index < Count && index >= 0)
                {
                    while (curIndex != index)
                    {
                        curNode = curNode.Next;
                        curIndex++;
                    }
                }
                else
                    throw new ArgumentException("ERROR: Invalid index!");

                return curNode.Value;
            }
            set
            {
                Node curNode = headNode;
                int curIndex = 0;

                if (index < Count && index >= 0)
                {
                    while (curIndex != index)
                    {
                        curNode = curNode.Next;
                        curIndex++;
                    }
                }
                else
                    throw new ArgumentException("ERROR: Invalid index!");

                curNode.Value = value;
            }
        }

        public bool MoveNext()  // IEnumerator
        {
            position++;
            return (position < Count);
        }

        public void Reset() // IEnumerator
        {
            position = 0;
        }

        public IEnumerator GetEnumerator()  //IEnumerable
        {
            return this;
        }
    }
}