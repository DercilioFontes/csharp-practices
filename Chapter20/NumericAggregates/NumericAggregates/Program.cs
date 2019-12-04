using System;
using System.Linq;
using static System.Console;

namespace NumericAggregates
{
    class Program
    {
        static void Main()
        {
            int[] numbers = GenerateLotsOfNumbers(12_345_678);

            WriteLine("Numeric Aggregates");

            var queryResults = from n in numbers
                               where n > 1000
                               select n;

            WriteLine("Count of Numbers > 1000:");
            WriteLine(queryResults.Count().ToString("N0"));

            WriteLine("Max of Numbers > 1000:");
            WriteLine(queryResults.Max().ToString("N0"));

            WriteLine("Min of Numbers > 1000:");
            WriteLine(queryResults.Min().ToString("N0"));

            WriteLine("Average of Numbers > 1000:");
            WriteLine(queryResults.Average().ToString("N2"));

            WriteLine("Sum of Numbers > 1000:");
            WriteLine(queryResults.Sum(n => (long)n).ToString("N0"));

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
