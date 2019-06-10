using static System.Console;

namespace Ch13Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            var curries = new[]
            {
                new {MainIngredient = "Lamb", Style = "Dhansak", Spiciness = 5},
                new {MainIngredient = "Lamb", Style = "Dhansak", Spiciness = 5},
                new {MainIngredient = "Chicken", Style = "Dhansak", Spiciness = 5},
            };
            WriteLine(curries[0].ToString());
            WriteLine(curries[0].GetHashCode());
            WriteLine(curries[1].GetHashCode());
            WriteLine(curries[2].GetHashCode());
            WriteLine(curries[0].Equals(curries[1]));
            WriteLine(curries[0].Equals(curries[2]));
            WriteLine(curries[0] == curries[1]);
            WriteLine(curries[0] == curries[2]);
            ReadKey();
        }
    }
}
