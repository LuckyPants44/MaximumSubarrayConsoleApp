using System;

namespace MaximumSubarrayConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var array = new int[] { 10, -3, -12, 8, 42, 1, -7, 0, 3 };

            Console.WriteLine($"Находим отрезок с максимальной суммой из массива: {string.Join(", ", array)}");

            var result = GetMaxSumSubarray(array);

            Console.WriteLine($"Сумма: {result.Sum}");
            Console.WriteLine($"Начальный индекс: {result.StartIndex}");
            Console.WriteLine($"Конечный индекс: {result.EndIndex}");

            Console.ReadKey();
        }

        public static (int Sum, int StartIndex, int EndIndex) GetMaxSumSubarray(int[] array)
        {
            var resultSum = array[0];
            var startIndex = 0;
            var endIndex = 0;

            var tempSum = 0;
            var tempIndex = -1;

            for (var i = 0; i < array.Length; i++)
            {
                tempSum += array[i];

                if (tempSum > resultSum)
                {
                    resultSum = tempSum;
                    startIndex = tempIndex + 1;
                    endIndex = i;
                }

                if (tempSum < 0)
                {
                    tempSum = 0;
                    tempIndex = i;
                }
            }

            return (resultSum, startIndex, endIndex);
        }
    }
}