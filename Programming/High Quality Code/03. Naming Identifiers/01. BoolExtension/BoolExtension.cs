namespace BoolExtension
{
    using System;

    public class BoolExtension
    {
        private const int MaxCount = 6;

        public static void Main()
        {
            BoolExtension.BoolMethods instance = new BoolExtension.BoolMethods();
            instance.PrintBoolState(true);
        }

        public class BoolMethods
        {
            public void PrintBoolState(bool currentState)
            {
                string boolAsString = currentState.ToString();
                Console.WriteLine(boolAsString);
            }
        }
    }
}
