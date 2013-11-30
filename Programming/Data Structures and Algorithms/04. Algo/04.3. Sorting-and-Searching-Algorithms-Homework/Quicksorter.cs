namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            QuickSort(collection, 0, collection.Count - 1);
        }

        public void QuickSort(IList<T> list, int left, int right)
        {
            int initialLeft = left;
            int initialRight = right;
            T pivotValue = list[initialLeft];

            while (left < right)
            {
                while ((list[right].CompareTo(pivotValue)) >= 0 && (left < right))
                {
                    right--;
                }
                if (left != right)
                {
                    list[left] = list[right];
                    left++;
                }
                while ((list[left].CompareTo(pivotValue)) <= 0 && (left < right))
                {
                    left++;
                }
                if (left != right)
                {
                    list[right] = list[left];
                    right--;
                }
            }

            list[left] = pivotValue;
            int pivotIndex = left;

            if ((pivotIndex - 1) > initialLeft)
            {
                QuickSort(list, initialLeft, pivotIndex - 1);
            }
            if ((pivotIndex + 1) < initialRight)
            {
                QuickSort(list, pivotIndex + 1, initialRight);
            }
        }
    }
}
