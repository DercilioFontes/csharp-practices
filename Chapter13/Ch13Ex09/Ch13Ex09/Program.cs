using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch13Ex09
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] curries = { "pathia", "jalfrezi", "korma" };
            WriteLine(curries.Aggregate((a, b) => a + " " + b));
            WriteLine(curries.Aggregate<string, int>(0, (a, b) => a + b.Length));
            WriteLine(curries.Aggregate<string, string, string>("Some curries:", (a, b) => a + " " + b, a => a));
            WriteLine(curries.Aggregate<string, string, int>("Some curries:", (a, b) => a + " " + b, a => a.Length));
            ReadKey();
        }
    }
}
