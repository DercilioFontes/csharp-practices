using System;
using static System.Console;

namespace Ch11Ex03
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Primes primesFrom2To1000 = new Primes(2, 10000000);
            foreach (long i in primesFrom2To1000)
                Write($"{i} ");
            ReadKey();
        }
    }
}
