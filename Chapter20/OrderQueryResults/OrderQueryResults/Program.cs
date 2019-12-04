using System.Linq;
using static System.Console;

namespace OrderQueryResults
{
    class Program
    {
        static void Main()
        {
            string[] names = { "Alonso", "Zheng", "Smith", "Jones", "Smythe", "Small", "Ruiz", "Hsieh", "Jorgenson", "Ilyich", "Singh", "Samba", "Fatimah" };

            var queryResults = from n in names
                               where n.StartsWith("S")
                               orderby n/*.Substring(n.Length - 1)*/
                               select n;

            WriteLine("Names beginning with S ordered alphabetically:");

            foreach(var item in queryResults)
            {
                WriteLine(item);
            }

            Write("Program finished, press Enter/Return to continue:");
            _ = ReadLine();
        }
    }
}
