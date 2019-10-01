using System;
using System.Diagnostics;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1, 2, 5, 4, 2, 0 };
            var index = Search.LinearSearch(array, 2);
            Debug.Assert(index == 4);
            index = Search.BetterLinearSearch(array, 2);
            Debug.Assert(index == 1);
            index = Search.SentinelLinearSearch(array, 2);
            Debug.Assert(index == 1);
            index = Search.RecursiveLinearSearch(array, array.Length - 1, 0, 10);
            Debug.Assert(index == -1);
            array = new int[] { 1, 2, 3, 4, 5, 6 };
            index = Search.BinarySearch(array, 10);
            Debug.Assert(index == -1);
            index = Search.BinarySearch(array, 4);
            index = Search.RecursiveBinarySearch(array, 0, array.Length - 1, 10);
            Debug.Assert(index == -1);
            index = Search.RecursiveBinarySearch(array, 0, array.Length - 1, 4);
            Debug.Assert(index == 3);
        }
    }
}
