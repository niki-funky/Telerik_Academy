namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            collection.Clear();
            collection = MergeSort(collection);
        }

        public IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int mid = collection.Count / 2;

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            for (int i = 0; i < mid; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = mid; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            return Merge(MergeSort(left), MergeSort(right));
        }

        public IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> rv = new List<T>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (((IComparable)left[0]).CompareTo(right[0]) > 0)
                {
                    rv.Add(right[0]);
                    right.RemoveAt(0);
                }
                else
                {
                    rv.Add(left[0]);
                    left.RemoveAt(0);
                }
            }

            for (int i = 0; i < left.Count; i++)
            {
                rv.Add(left[i]);
            }

            for (int i = 0; i < right.Count; i++)
            {
                rv.Add(right[i]);
            }

            return rv;
        }
    }
}
