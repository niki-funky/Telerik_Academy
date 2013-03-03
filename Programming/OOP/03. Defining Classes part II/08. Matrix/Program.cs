using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            Matrix<int> intMatrix = new Matrix<int>(3, 3);
            intMatrix[0, 0] = 1;
            intMatrix[0, 1] = 2;
            intMatrix[0, 2] = 3;
            intMatrix[1, 0] = 4;
            intMatrix[1, 1] = 5;
            intMatrix[1, 2] = 6;
            intMatrix[2, 0] = 7;
            intMatrix[2, 1] = 8;
            intMatrix[2, 2] = 9;

            Matrix<int> intMatrix2 = new Matrix<int>(3, 3);
            intMatrix2[0, 0] = 1;
            intMatrix2[0, 1] = 2;
            intMatrix2[0, 2] = 3;
            intMatrix2[1, 0] = 4;
            intMatrix2[1, 1] = 5;
            intMatrix2[1, 2] = 6;
            intMatrix2[2, 0] = 7;
            intMatrix2[2, 1] = 8;
            intMatrix2[2, 2] = 9;

            Matrix<int> intMatrix3 = new Matrix<int>(2, 2);
            intMatrix3[0, 0] = 1;
            intMatrix3[0, 1] = 2;
            intMatrix3[1, 0] = 4;
            intMatrix3[1, 1] = 5;

            Matrix<int> intMatrix4 = intMatrix + intMatrix2;
            Console.WriteLine(intMatrix4.ToString());

            //this throws exception
            //Matrix<int> intMatrix5 = intMatrix + intMatrix3;
        }
    }
}
