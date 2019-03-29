using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch05Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] friendNames = { "Todd Anthony", "Kevin Holton", "Shane Laigle" };

            WriteLine($"Here are {friendNames.Length} of my friends:");

            WriteLine("for");
            for (int i = 0; i < friendNames.Length; i++)
            {
                WriteLine(friendNames[i]);
            }

            WriteLine("foreach");
            foreach (string name in friendNames)
            {
                WriteLine(name);
            }

            ReadKey();
        }
    }
}
