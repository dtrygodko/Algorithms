using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class Search
    {
        public static int LinearSearch(int[] array, int x)
        {
            var result = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == x)
                {
                    result = i;
                }
            }
            return result;
        }

        public static int BetterLinearSearch(int[] array, int x)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int SentinelLinearSearch(int[] array, int x)
        {
            var n = array.Length - 1;
            var last = array[n];
            var i = 0;
            while (array[i] != x)
            {
                i++;
            }
            array[n] = last;
            if (i < n || array[n] == x)
            {
                return i;
            }
            return -1;
        }

        public static int RecursiveLinearSearch(int[] array, int n, int i, int x)
        {
            if (i > n)
            {
                return -1;
            }
            if (array[i] == x)
            {
                return i;
            }
            else
            {
                return RecursiveLinearSearch(array, n, i + 1, x);
            }
        }

        public static int BinarySearch(int[] array, int x)
        {
            var n = array.Length - 1;
            var p = 0;
            var r = n;
            while (p <= r)
            {
                var q = (p + r) / 2;
                if (array[q] == x)
                {
                    return q;
                }
                if (array[q] > x)
                {
                    r = q - 1;
                }
                else
                {
                    p = q + 1;
                }
            }
            return -1;
        }

        public static int RecursiveBinarySearch(int[] array, int p, int r, int x)
        {
            if (p > r)
            {
                return -1;
            }
            else
            {
                var q = (p + r) / 2;
                if (array[q] == x)
                {
                    return q;
                }
                if (array[q] > x)
                {
                    return RecursiveBinarySearch(array, p, q - 1, x);
                }
                else
                {
                    return RecursiveBinarySearch(array, q + 1, r, x);
                }
            }
        }
    }
}
