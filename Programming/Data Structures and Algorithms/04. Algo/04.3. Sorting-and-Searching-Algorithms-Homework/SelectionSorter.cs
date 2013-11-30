namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            for (int i = 0; i < collection.Count - 1; i++)
            {
                int indexMin = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[indexMin]) < 0)
                    {
                        indexMin = j;
                    }
                }

                if (indexMin != i)
                {
                    T value = collection[i];
                    collection[i] = collection[indexMin];
                    collection[indexMin] = value;
                }
            }
        }
    }
}
