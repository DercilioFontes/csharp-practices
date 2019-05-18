using System;
using System.Collections;

namespace SimpleIteratos
{
    class MainClass
    {
        public static IEnumerable SimpleList()
        {
            yield return "string 1";
            yield return "string 2";
            yield return "string 3";
        }

        public static void Main(string[] args)
        {
            foreach(string item in SimpleList())
            {
                Console.WriteLine(item);
            }
        }
    }
}
