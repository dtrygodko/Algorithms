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
    }
}
