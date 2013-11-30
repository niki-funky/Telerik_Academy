
namespace HashSet
{
    using System;

    internal class Demo
    {
        public static void Main()
        {
            try
            {
                HashSet<int> hashSet = new HashSet<int>();

                hashSet.Add(1);
                hashSet.Add(5);
                hashSet.Add(2);
                hashSet.Add(33);
                Console.WriteLine("Count is : {0}", hashSet.Count);

                hashSet.Remove(2);
                Console.WriteLine("Count is : {0}", hashSet.Count);

                Console.WriteLine(hashSet.Find(5));
                Console.WriteLine(hashSet.Contains(5));

                int[] numArray = new int[] { 5, 11, 33 };
                int[] array = numArray;
                hashSet.UnionWith(array);
                Console.WriteLine("Count is : {0}", hashSet.Count);

                int[] numArray1 = new int[] { 5, 11, 22 };
                int[] array2 = numArray1;
                hashSet.Intersect(array2);
                Console.WriteLine("Count is : {0}", hashSet.Count);

                hashSet.Clear();
                Console.WriteLine("Count is : {0}", hashSet.Count);
                Console.WriteLine(hashSet.Find(5));
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
        }
    }
}