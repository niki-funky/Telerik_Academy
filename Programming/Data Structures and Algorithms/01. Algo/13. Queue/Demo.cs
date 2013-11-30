using System;
using System.Linq;

namespace LinkedQueue
{
    using System;
    using System.Linq;

    // 13. Implement the ADT queue as dynamic linked list. 
    // Use generics (LinkedQueue<T>) to allow storing different data types in the queue.

    class Demo
    {
        static void Main()
        {
            try
            {
                LinkedQueue<string> queue = new LinkedQueue<string>();
                queue.Enqueue("Message One");
                queue.Enqueue("Message Two");
                queue.Enqueue("Message Three");
                queue.Enqueue("Message Four");

                Console.WriteLine(queue.Peek());
                Console.WriteLine(queue.Contains("Message Three"));

                var array = queue.ToArray();
                Console.WriteLine(string.Join(", ", array));

                while (queue.Count > 0)
                {
                    string message = queue.Dequeue();
                    Console.WriteLine(message);
                }

                queue.Dequeue();
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.WriteLine(iex.TargetSite + " -> " + iex.Message);
            }
            catch (NullReferenceException nex)
            {
                Console.WriteLine(nex.TargetSite + " -> " + nex.Message);
            }
        }
    }
}
