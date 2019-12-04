using System;
using System.Linq;
using static System.Console;

namespace LargeNumberQuery
{
    class Program
    {
        static void Main()
        {
            int[] numbers = GenerateLotsOfNumbers(12_345_678);

            var queryResults = from n in numbers
                               where n < 1_000
                               select n;

            WriteLine("Numbers less than 1000:");

            foreach(var item in queryResults)
            {
                WriteLine(item);
            }

            Write("Program finished, press Enter/Return to continue:");
            _ = ReadLine();
        }

        private static int[] GenerateLotsOfNumbers(int count)
        {
            Random generator = new Random(0);
            int[] result = new int[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = generator.Next();
            }

            return result;
        }
    }
}
