
namespace ReverseIntegersUsingStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    // 02. Write a program that reads N integers from the console and 
    // reverses them using a stack. Use the Stack<int> class.

    public class ReverseIntegersUsingStack
    {
        private static Stack<int> sequence;

        private static void ReadUserInput()
        {
            sequence = new Stack<int>();
            var inputLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(inputLine))
            {
                int number = int.Parse(inputLine);
                sequence.Push(number);

                inputLine = Console.ReadLine();
            }
        }

        // first approach
        /// <summary>
        /// Reverses given Stack by bringing the bottom most element to the top
        /// of the stack and pushing all the other elements one down,
        /// as many times as needed.
        /// </summary>
        /// <param name="stack">Stack to be reversed.</param>
        private static void ReverseStack(Stack<int> stack)
        {
            if (stack.Count > 0)
            {
                int item = stack.Pop();
                if (stack.Count != 1)
                {
                    ReverseStack(stack);
                }

                PushToStack(stack, item);
            }
        }

        public static void PushToStack(Stack<int> stack, int number)
        {
            int item = stack.Pop();
            if (stack.Count != 0)
            {
                PushToStack(stack, number);
            }
            else
            {
                stack.Push(number);
            }

            stack.Push(item);
        }

        // second approach
        /// <summary>
        /// Reverses given Stack by creating a new Stack,
        /// using IEnumerable<T> of the given Stack.
        /// </summary>
        /// <typeparam name="T">Type of objects in the Stack.</typeparam>
        /// <param name="stack">Stack to be reversed.</param>
        /// <returns>Reversed Stack.</returns>
        /// <remarks>Iterating over a stack iterates in "pop" order</remarks>
        private static Stack<T> ReveresedStack<T>(Stack<T> stack)
        {
            var reversedStack = new Stack<T>(stack);
            return reversedStack;
        }

        public static void PrintStack(IEnumerable collection)
        {
            if ((collection as ICollection).Count == 0)
            {
                Console.WriteLine("Stack is empty!");
            }
            Console.Write("{");
            foreach (Object obj in collection)
            {
                Console.Write(" {0}", obj);
            }

            Console.WriteLine(" }");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter some numbers: ");
            ReadUserInput();

            Console.WriteLine("Stack before reverse:");
            PrintStack(sequence);

            ReverseStack(sequence);
            //sequence = ReveresedStack(sequence);

            Console.WriteLine("Stack after reverse:");
            PrintStack(sequence);
        }
    }
}
