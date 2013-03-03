using System;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            #region test1
            GenericList<int> list = new GenericList<int>(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Console.WriteLine(list[1]);
            list[1] = 10;
            Console.WriteLine(list.ToString());
            Console.WriteLine("10 is at index: " + list.Find(10));
            list.RemoveAt(0);
            Console.WriteLine("Min is: " + list.Min());
            Console.WriteLine("Max is: " + list.Max());
            Console.WriteLine(list.ToString());
            Console.WriteLine("---------------" + "\n");
            #endregion

            #region test2
            GenericList<string> list2 = new GenericList<string>(2);
            list2.Add("Pesho");
            list2.Add("Gosho");
            list2.Add("Misho");
            Console.WriteLine(list2[1]);
            list2[1] = "Ceco";
            Console.WriteLine(list2.ToString());
            Console.WriteLine("Misho is at index: " + list2.Find("Misho"));
            list2.RemoveAt(0);
            Console.WriteLine("Min is: " + list2.Min());
            Console.WriteLine(list2.ToString());
            Console.WriteLine("---------------" + "\n");
            #endregion

            #region test3
            GenericList<object> list3 = new GenericList<object>(2);
            list3.Add("Pesho");
            list3.Add("Gosho");
            list3.Add("Misho");
            Console.WriteLine(list3[1]);
            list3[1] = "Ceco";
            Console.WriteLine(list3.ToString());
            Console.WriteLine("Misho is at index: " + list3.Find("Misho"));
            list3.RemoveAt(0);
            Console.WriteLine(list3.Min());
            Console.WriteLine(list3.ToString());
            #endregion
        }
    }
}
