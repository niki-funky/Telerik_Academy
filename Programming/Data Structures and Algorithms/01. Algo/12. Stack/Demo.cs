namespace Stack
{
    using System;
    using System.Linq;

    // 12. Implement the ADT stack as auto-resizable array. 
    // Resize the capacity on demand (when no space is available to add / insert a new element).

    class Demo
    {
        public static void Main()
        {
            try
            {
                Stack<int> stack = new Stack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                stack.Push(4);
                stack.Push(5);

                int[] array = stack.ToArray();
                Console.WriteLine(string.Join(", ", array));

                Console.WriteLine(stack.Peek());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Contains(0));
                stack.Clear();
                Console.WriteLine(stack.Peek());
            }
            catch (ArgumentNullException aex)
            {
                Console.WriteLine(aex.TargetSite + " -> " + aex.Message);
            }
        }
    }
}
