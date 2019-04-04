using System;

namespace Ch03Ex01
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int myInteger;
            string myString;

            myInteger = 17;
            myString = "\"myInteger\" is";
            Console.WriteLine($"{myString} {myInteger}");
            Console.WriteLine("\u0027 \u0022 \u005c \u0000 \u0007 \u0008 \000c \000a \000d \0009 \000b");
            Console.WriteLine(@"Verbatim string literal 
            '
            \
            \n
            ");
            Console.ReadKey();
        }
    }
}
