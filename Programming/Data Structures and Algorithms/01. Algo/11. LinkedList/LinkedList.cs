namespace LinkedList
{
    using System;
    using System.Linq;

    class LinkedList<T> where T : IComparable<T>
    {
        public LinkedListItem<T> FirstElement { get; set; }
        public int Count { get; private set; }

        public LinkedList()
        {
            this.FirstElement = null;
            this.Count = 0;
        }

        public LinkedList(LinkedListItem<T> Node)
        {
            this.FirstElement = Node;
            this.Count++;
        }

        public LinkedList(T value)
        {
            LinkedListItem<T> tempNode = new LinkedListItem<T>(value);
            this.FirstElement = tempNode;
            this.Count++;
        }

        public void AddFirst(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new LinkedListItem<T>(value);
                this.Count++;
            }
            else
            {
                LinkedListItem<T> newListItem = new LinkedListItem<T>(value, this.FirstElement);
                this.FirstElement = newListItem;
                this.Count++;
            }
        }

        public void AddLast(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new LinkedListItem<T>(value);
                this.Count++;
            }
            else
            {
                LinkedListItem<T> next = this.FirstElement;

                while (next.NextItem != null)
                {
                    next = next.NextItem;
                }

                next.NextItem = new LinkedListItem<T>(value);
                this.Count++;
            }
        }

        public void AddAfter(LinkedListItem<T> item, T value)
        {
            LinkedListItem<T> next = this.FirstElement;
            while (next != item && next != null)
            {
                next = next.NextItem;
                if (next == null)
                {
                    throw new ArgumentException("The ListItem is not in the LinkedList!");
                }
            }
            LinkedListItem<T> newListItem = new LinkedListItem<T>(value);
            newListItem.NextItem = next.NextItem;
            next.NextItem = newListItem;
            this.Count++;
        }

        public void AddBefore(LinkedListItem<T> item, T value)
        {
            if (item == this.FirstElement)
            {
                LinkedListItem<T> newListItem = new LinkedListItem<T>(value, this.FirstElement);
                this.FirstElement = newListItem;
                this.Count++;
            }
            else
            {
                LinkedListItem<T> next = this.FirstElement;

                while (next.NextItem != item)
                {
                    next = next.NextItem;
                    if (next == null)
                    {
                        throw new ArgumentException("The ListItem is not in the LinkedList!");
                    }
                }

                LinkedListItem<T> newListItem = new LinkedListItem<T>(value);
                newListItem.NextItem = next.NextItem;
                next.NextItem = newListItem;
                this.Count++;
            }
        }

        public void AddItemAt(T value, int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }
            if (index == 0)
            {
                throw new ArgumentException("Use instead method RemoveFirst.");
            }
            else
            {
                if (index == this.Count)
                {
                    LinkedListItem<T> newListItem = new LinkedListItem<T>(value, this.FirstElement);
                    this.FirstElement = newListItem;
                }
                else
                {
                    LinkedListItem<T> currentElement = this.FirstElement;
                    LinkedListItem<T> newListItem = new LinkedListItem<T>(value);
                    for (int i = 0; i < this.Count - index - 2; i++)
                    {
                        currentElement = currentElement.NextItem;
                    }
                    newListItem.NextItem = currentElement.NextItem;
                    currentElement.NextItem = newListItem;
                }
                this.Count++;
            }
        }

        public void RemoveFirst()
        {
            this.FirstElement = this.FirstElement.NextItem;
        }

        public void RemoveLast()
        {
            LinkedListItem<T> currentElement = this.FirstElement.NextItem;
            this.FirstElement = currentElement;
            this.Count--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }
            else
            {
                if (this.Count - 1 == index)
                {
                    this.RemoveLast();
                }
                else
                {
                    LinkedListItem<T> currentElement = this.FirstElement;
                    for (int i = 0; i < this.Count - index - 2; i++)
                    {
                        currentElement = currentElement.NextItem;
                    }
                    currentElement.NextItem = currentElement.NextItem.NextItem;
                    this.Count--;
                }
            }
        }

        public void Clear()
        {
            this.FirstElement = null;
        }

        public bool Contains(T value)
        {
            LinkedListItem<T> currentElement = this.FirstElement;
            while (currentElement.NextItem != null)
            {
                if (currentElement.Value.Equals(value))
                {
                    return true;
                }
                currentElement = currentElement.NextItem;
            }
            return false;
        }

        public T this[int index]
        {
            get
            {
                int counter = 0;
                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
                }
                else
                {
                    LinkedListItem<T> currentElement = this.FirstElement;
                    while (counter < index)
                    {
                        currentElement = currentElement.NextItem;
                        counter++;
                    }

                    return currentElement.Value;
                }
            }
        }
    }
}