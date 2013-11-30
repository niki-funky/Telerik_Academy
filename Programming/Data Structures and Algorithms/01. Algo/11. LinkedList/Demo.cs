namespace LinkedList
{
    using System;
    using System.Linq;

    // 11. Implement the data structure linked list. Define a class ListItem<T> 
    // that has two fields: value (of type T) and NextItem (of type ListItem<T>).
    // Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).

    public class Demo
    {
        public static void Main()
        {
            try
            {
                LinkedList<int> linkedList = new LinkedList<int>();
                linkedList.AddFirst(5);
                linkedList.AddLast(10);
                linkedList.AddFirst(20);
                // returns Exception
                //linkedList.AddItemAt(30, 0);
                linkedList.AddItemAt(30, 1);

                Console.WriteLine(linkedList[1]);

                linkedList.AddLast(50);
                linkedList.AddAfter(linkedList.FirstElement.NextItem.NextItem.NextItem, 60);
                linkedList.AddBefore(linkedList.FirstElement, 0);
                linkedList.RemoveFirst();
                linkedList.RemoveLast();
                linkedList.RemoveAt(1);

                Console.WriteLine(linkedList[1]);
                Console.WriteLine(linkedList.Count);

                linkedList.RemoveAt(5);
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.TargetSite + " -> " + aex.Message);
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.WriteLine(iex.TargetSite + " -> " + iex.Message);
            }
        }
    }
}
