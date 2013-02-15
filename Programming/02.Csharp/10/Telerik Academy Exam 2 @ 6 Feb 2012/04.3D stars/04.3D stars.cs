using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikAcademyExam2_6Feb2012
{
    class _3Dstars
    {
        //variables
        static int width, height, depth;
        static int stars;
        static Dictionary<char, int> result = new Dictionary<char, int>();

        static void FindAstar(char[, ,] cube, int w, int h, int d)
        {
            //variables
            bool shines = true;
            char core = cube[w, h, d];

            shines = (cube[w + 1, h, d] == core)
                 && (cube[w - 1, h, d] == core)
                 && (cube[w, h + 1, d] == core)
                 && (cube[w, h - 1, d] == core)
                 && (cube[w, h, d + 1] == core)
                 && (cube[w, h, d - 1] == core);

            if (shines)
            {
                if (!result.ContainsKey(core))
                {
                    result.Add(core, 0);
                }
                result[core]++;
            }
        }

        static void Main()
        {
            //build the cube
            string[] sizeOfCube = Console.ReadLine().Split(' ');
            width = int.Parse(sizeOfCube[0]);
            height = int.Parse(sizeOfCube[1]);
            depth = int.Parse(sizeOfCube[2]);
            char[, ,] cube = new char[width, height, depth];
            for (int h = 0; h < height; h++)
            {
                string[] layer = Console.ReadLine().Split(' ');
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        cube[w, h, d] = layer[d][w];
                    }
                }
            }

            //find a star
            for (int w = 1; w < width - 1; w++)
            {
                for (int h = 1; h < height - 1; h++)
                {
                    for (int d = 1; d < depth - 1; d++)
                    {
                        FindAstar(cube, w, h, d);
                    }
                }
            }

            //find number of stars
            foreach (KeyValuePair<char, int> p in result)
            {
                stars += p.Value;
            }

            //print number
            Console.WriteLine(stars);

            //sort dictionary in alphabetical order of colors
            var sorted = result.OrderBy(x => x.Key);

            //print color of stars
            foreach (var star in sorted)
            {
                Console.WriteLine("{0} {1}", star.Key, star.Value);
            }
        }
    }
}
