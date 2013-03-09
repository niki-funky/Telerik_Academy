using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerable
{
    // 02.Implement a set of extension methods for IEnumerable<T> that
    // implement the following group functions: sum, product, min, max, average.

    public static class IEnumerable
    {
        public static T Sum<T>(this IEnumerable<T> iface) where T : IComparable<T>
        {
            dynamic sum = 0;
            foreach (var item in iface)
            {
                sum += item;
            }
            return sum;
        }

        public static T Product<T>(this IEnumerable<T> iface) where T : IComparable<T>
        {
            dynamic product = 1;
            foreach (var item in iface)
            {
                product *= item;
            }
            return product;
        }

        public static T Min<T>(this IEnumerable<T> iface) where T : IComparable<T>
        {
            T min = default(T);
            bool first = true;
            foreach (var item in iface)
            {
                if (first)
                {
                    min = item;
                    first = false;
                }
                else
                {
                    if (min.CompareTo(item) > 0)
                    {
                        min = item;
                    }
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> iface) where T : IComparable<T>
        {
            T max = default(T);
            bool first = true;
            foreach (var item in iface)
            {
                if (first)
                {
                    max = item;
                    first = false;
                }
                else
                {
                    if (max.CompareTo(item) < 0)
                    {
                        max = item;
                    }
                }
            }
            return max;
        }

        public static decimal Average<T>(this IEnumerable<T> iface) where T : IComparable<T>
        {
            dynamic average = 0;
            decimal counter = 0;
            foreach (var item in iface)
            {
                average += item;
                counter++;
            }
            return average / counter;
        }
    }
}
