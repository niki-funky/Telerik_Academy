using System;
using System.Linq;
using System.Text;

namespace GenericList
{
    class GenericList<T>
    {
        //fields
        private int counter = 0;

        private int Capacity { get; set; }
        private T[] array;

        //constructor
        public GenericList(int size)
        {
            this.array = new T[size];
            this.Capacity = size;
        }

        // Indexer declaration
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.array.Length)
                {
                    return this.array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < this.array.Length)
                {
                    this.array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        //methods
        //Add element to array
        public void Add(T element)
        {
            if (counter < array.Length)
            {
                this.array[counter] = element;
                this.counter++;
            }
            else
            {
                int index = this.array.Length;
                //create new array of double size using Linq
                this.array = (this.array ?? Enumerable.Empty<T>()).Concat(new T[this.array.Length]).ToArray();
                array[index] = element;
            }
        }

        //remove element at index
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < this.array.Length)
            {
                //remove item at index using Linq
                this.array = this.array.Where((val, idx) => idx != index).ToArray();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //find elements' index using Linq
        public int Find(T element)
        {
            return this.array.Select((value, index) =>
                            new { value, index }).First(x => x.value.Equals(element)).index;
        }

        //clear array
        public void Clear()
        {
            this.array = new T[this.array.Length];
        }

        public T Min()
        {
            dynamic min = this.array[0];

            for (int i = 1; i < this.array.Length; i++)
            {
                try
                {
                    if ((min as IComparable<T>).CompareTo(this.array[i]) > 0)
                    {
                        min = this.array[i];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Objects in the List aren't of type IComparable! "
                        + "\n" + ex.Message);
                }
            }
            return min != null ? min : "null";
        }

        public T Max()
        {
            dynamic max = this.array[0];

            for (int i = 1; i < this.array.Length; i++)
            {
                try
                {
                    if ((max as IComparable<T>).CompareTo(this.array[i]) < 0)
                    {
                        max = this.array[i];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Objects in the List aren't of type IComparable! "
                        + "\n" + ex.Message);
                }
            }
            return max != null ? max : "null";
        }

        //method overriding ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            for (int i = 0; i < this.array.Length; i++)
            {
                sb.Append(this.array[i]);
                if (i != this.array.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}