namespace MergeSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] arraySource = new int[random.Next(10, 30)];

            for (int i = 0; i < arraySource.Length; i++)
            {
                arraySource[i] = random.Next(100);
            }

            Console.Write("[");
            for (int i = 0; i < arraySource.Length; i++)
            {
                Console.Write($"{arraySource[i]}");
                if (i < arraySource.Length - 1)
                    Console.Write("\t");
            }
            Console.Write("]");
            Console.WriteLine();
            int[] result = MergeSort(arraySource);

            Console.Write("[");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write($"{result[i]}");
                if (i < arraySource.Length - 1)
                    Console.Write("\t");
            }
            Console.Write("]");
        }

        static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
                return array;

            int middle = array.Length / 2;

            int[] arrayLeft = CopyArray(array, 0, middle);
            int[] arrayRight = CopyArray(array, middle, array.Length);

            int[] array1 = MergeSort(arrayLeft);
            int[] array2 = MergeSort(arrayRight);

            int index1 = 0;
            int index2 = 0;

            int[] arraySorted = new int[array1.Length + array2.Length];

            for (int i = 0; i < arraySorted.Length; i++)
            {
                if (index1 == array1.Length)
                {
                    arraySorted[i] = array2[index2++];
                    continue;
                }
                else if (index2 == array2.Length)
                {
                    arraySorted[i] = array1[index1++];
                    continue;
                }

                if (array1[index1] <= array2[index2])
                {
                    arraySorted[i] = array1[index1++];
                }
                else if (array1[index1] > array2[index2])
                {
                    arraySorted[i] = array2[index2++];
                }
            }

            return arraySorted;
        }

        static int[] CopyArray(int[] originArray, int startIndex, int endIndex)
        {
            int[] result = new int[endIndex - startIndex];

            int index = 0;

            while (startIndex < endIndex)
            {
                result[index++] = originArray[startIndex++];
            }

            return result;
        }
    }
}