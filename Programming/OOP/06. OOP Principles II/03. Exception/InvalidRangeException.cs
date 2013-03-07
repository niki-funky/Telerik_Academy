using System;
using System.Linq;

namespace Exceptions
{
    public class InvalidRangeException<T> : Exception
    {
        public T Min { get; private set; }
        public T Max { get; private set; }

        //constructors
        public InvalidRangeException() { }

        public InvalidRangeException(string message, Exception ex)
            : base(message, ex)
        {
        }

        public InvalidRangeException(string message, T min, T max)
            : base(message)
        {
            this.Min = min;
            this.Max = max;
        }
    }
}
