//-----------------------------------------------------------------------
// <copyright file="AssertionsHomework.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
using System;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void SelectionSort<T>(T[] array)
        where T : IComparable<T>
    {
        if (array == null)
        {
            throw new ArgumentNullException("Array cannot be null.");
        }

        for (int index = 0; index < array.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(array, index, array.Length - 1);
            Swap(ref array[index], ref array[minElementIndex]);
        }
    }

    public static int BinarySearch<T>(T[] array, T value)
        where T : IComparable<T>
    {
        if (array == null)
        {
            throw new ArgumentNullException("Array cannot be null.");
        }

        if (array.Length == 0)
        {
            return -1;
        }

        return BinarySearch(array, value, 0, array.Length - 1);
    }

    private static int BinarySearch<T>(T[] array, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(array != null, "Array is null.");
        Debug.Assert(array.Length > 0, "Array is empty");
        Debug.Assert(
            startIndex >= 0 && startIndex < array.Length,
            "Start index is not valid.",
            "Start index must be bigger than zero and less than {0}.",
            array.Length - 1);
        Debug.Assert(
            endIndex >= 0 && endIndex < array.Length,
            "End index is not valid.",
            "End index must be bigger than zero and less than {0}.",
            array.Length - 1);
        Debug.Assert(startIndex <= endIndex, "Start index must be less than or equal to end index.");

        for (int i = 0; i < array.Length - 1; i++)
        {
            Debug.Assert(
                array[i].CompareTo(array[i + 1]) <= 0,
                "The array must be sorted.");
        }

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (array[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (array[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the left half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    private static int FindMinElementIndex<T>(T[] array, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(array != null, "Array is null.");
        Debug.Assert(array.Length > 0, "Array is empty");
        Debug.Assert(
            startIndex >= 0 && startIndex < array.Length,
            "Start index is not valid.",
            "Start index must be bigger than zero and less than {0}.",
            array.Length - 1);
        Debug.Assert(
            endIndex >= 0 && endIndex < array.Length,
            "End index is not valid.",
            "End index must be bigger than zero and less than {0}.",
            array.Length - 1);
        Debug.Assert(startIndex <= endIndex, "Start index must be less than or equal to end index.");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (array[i].CompareTo(array[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        for (int j = startIndex; j <= endIndex; j++)
        {
            Debug.Assert(
                array[minElementIndex].CompareTo(array[j]) <= 0,
                "Element is not the smallest one.");
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("array = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
