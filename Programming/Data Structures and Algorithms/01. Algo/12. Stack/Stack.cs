namespace Stack
{
    using System;
    using System.Linq;

    // 12. Implement the ADT stack as auto-resizable array. 
    // Resize the capacity on demand (when no space is available to add / insert a new element).

    class Stack<T> where T : IComparable
    {
        private const int DefaultCapacity = 4;
        private T[] stack;

        public int Count { get; private set; }

        public Stack()
        {
            this.stack = new T[DefaultCapacity];
            this.Count = 0;
        }

        public void Push(T value)
        {
            if (this.Count < this.stack.Length)
            {
                this.stack[this.Count] = value;
            }
            else
            {
                this.AutoGrow();
                this.stack[this.Count] = value;
            }
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count <= 0)
            {
                throw new ArgumentNullException("The stack is empty!");
            }
            T value = this.stack[this.Count - 1];
            this.stack[this.Count - 1] = default(T);
            this.Count--;

            return value;
        }

        public T Peek()
        {
            if (this.Count <= 0)
            {
                throw new ArgumentNullException("The stack is empty!");
            }
            T value = this.stack[this.Count - 1];

            return value;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.stack[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            this.stack = new T[1];
            this.Count = 0;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.stack[i];
            }

            return array;
        }

        public void TrimExcess()
        {
            T[] array = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.stack[i];
            }

            this.stack = array;
        }

        private void AutoGrow()
        {
            int newCapacity = stack.Length * 2;
            T[] newStack = new T[newCapacity];
            for (int i = 0; i < stack.Length; i++)
            {
                newStack[i] = this.stack[i];
            }
            this.stack = newStack;
        }
    }
}
