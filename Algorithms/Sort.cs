using System;

namespace Algorithms
{
    class Sorter
    {
        public static void SelectionSort(int[] array)
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                var smallest = i;
                for(int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[smallest])
                    {
                        smallest = j;
                    }
                }
                var temp = array[i];
                array[i] = array[smallest];
                array[smallest] = temp;
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i - 1;
                while(j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        private static void Merge(int[] array, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] b = new int[n1 + 1];
            int[] c = new int[n2 + 1];
            Array.Copy(array, p, b, 0, q - p + 1);
            Array.Copy(array, q + 1, c, 0, r - q);
            b[n1] = int.MaxValue;
            c[n2] = int.MaxValue;
            int i = 0, j = 0;
            for (int k = p; k <= r; k++)
            {
                if (b[i] <= c[j])
                {
                    array[k] = b[i++];
                }
                else
                {
                    array[k] = c[j++];
                }
            }
        }

        public static void MergeSort(int[] array, int p, int r)
        {
            if (p >= r)
            {
                return;
            }
            else
            {
                int q = (p + r) / 2;
                MergeSort(array, p, q);
                MergeSort(array, q + 1, r);
                Merge(array, p, q, r);
            }
        }

        private static int Partition(int[] array, int p, int r)
        {
            var randomIndex = new Random().Next(p, r);
            var t = array[randomIndex];
            array[randomIndex] = array[r];
            array[r] = t;

            int q = p;
            for (var u = p; u <= r - 1; u++)
            {
                if (array[u] <= array[r])
                {
                    var temp = array[q];
                    array[q] = array[u];
                    array[u] = temp;
                    q++;
                }
            }
            var temp1 = array[q];
            array[q] = array[r];
            array[r] = temp1;
            return q;
        }

        public static void QuickSort(int[] array, int p, int r)
        {
            if (p >= r)
            {
                return;
            }
            else
            {
                int q = Partition(array, p, r);
                QuickSort(array, p, q - 1);
                QuickSort(array, q + 1, r);
            }
        }

        private static int[] CountKeysEqual(int[] array, int n, int m)
        {
            var equal = new int[m];
            for (int i = 0; i < n; i++)
            {
                var key = array[i];
                equal[key] = equal[key] + 1;
            }
            return equal;
        }

        private static int[] CountKeysLess(int[] equal, int m)
        {
            int[] less = new int[m];
            for (int j = 1; j < m; j++)
            {
                less[j] = less[j - 1] + equal[j - 1];
            }
            return less;
        }

        private static int[] Rearrange(int[] array, int[] less, int n, int m)
        {
            int[] b = new int[n];
            int[] next = new int[m];
            for (int j = 0; j < m; j++)
            {
                next[j] = less[j] + 1;
            }
            for (int i = 0; i < n; i++)
            {
                var key = array[i];
                var index = next[key] - 1;
                b[index] = array[i];
                next[key] = next[key] + 1;
            }
            return b;
        }

        public static int[] CountingSort(int[] array, int n, int m)
        {
            var equal = CountKeysEqual(array, n, m);
            var less = CountKeysLess(equal, m);
            return Rearrange(array, less, n, m);
        }
    }
}
