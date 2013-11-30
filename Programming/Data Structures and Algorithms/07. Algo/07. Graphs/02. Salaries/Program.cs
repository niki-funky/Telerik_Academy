using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Salaries
{
    class Program
    {
        static long[] visited;
        static int[,] graph;

        private static long CalculateSalary(int employee)
        {
            if (visited[employee] > 0)
            {
                return visited[employee];
            }

            long salary = 0;
            for (int i = 0; i < visited.Length; i++)
            {
                if (graph[employee, i] == 1)
                {
                    salary += CalculateSalary(i);
                }
            }

            if (salary == 0)
            {
                salary = 1;
            }

            visited[employee] = salary;

            return salary;
        }

        static void Main(string[] args)
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            int c = int.Parse(Console.ReadLine());
            graph = new int[c, c];
            visited = new long[c];
            long sum = 0;

            for (int i = 0; i < c; i++)
            {
                char[] employeesAsString = Console.ReadLine().ToCharArray();

                for (int j = 0; j < c; j++)
                {
                    if (employeesAsString[j] == 'N')
                    {
                        graph[i, j] = 0;
                    }
                    else
                    {
                        graph[i, j] = 1;
                    }
                }
            }

            for (int i = 0; i < c; i++)
            {
                sum += CalculateSalary(i);
            }

            Console.WriteLine(sum);
        }
    }
}
