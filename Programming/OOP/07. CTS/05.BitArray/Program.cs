using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray
{
    // 05. Define a class BitArray64 to hold 64 bit values inside an ulong value. 
    // Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

    class Program
    {
        static void Main(string[] args)
        {
            #region test1

            BitArray64 bitObj = new BitArray64(31012365);
            BitArray64 bitObj2 = new BitArray64(311);

            foreach (var item in bitObj)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("31012365 Equals 311: " + bitObj.Equals(bitObj2));
            Console.WriteLine("HashCode: " + bitObj.GetHashCode());
            Console.WriteLine("Bit[13] is: " + bitObj[13]);
            Console.WriteLine("Original number is: " + bitObj.Number);
            bitObj[13] = 0;
            Console.WriteLine("Number after setting bit[13] to 0 is: " + bitObj.Number);
            Console.WriteLine(bitObj==bitObj2);

            #endregion
        }
    }
}
