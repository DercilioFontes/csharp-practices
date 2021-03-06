﻿using System;
using System.IO;

namespace StreamWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileStream aFile = new FileStream("Log.txt", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);
                bool truth = true;

                // Write data to file.
                sw.WriteLine("Hello to you.");
                sw.Write($"It is now {DateTime.Now.ToLongDateString()}");
                sw.Write(" and things are looking good.");
                sw.Write($" It's {truth} that C# is fun.");
                sw.Close();
            }
            catch (IOException e)
            {

                Console.WriteLine("An IO exception  has been thrown!");
                Console.WriteLine(e.ToString());
                Console.ReadLine();
                return;
            }
        }
    }
}
