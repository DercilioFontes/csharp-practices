using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch11Ex02b
{
    class Program
    {
        static void Main(string[] args)
        {
            Animals animalCollection = new Animals
            {
                { "Donna", (Animal)(new Cow("Donna")) },
                { "Kevin", (Animal)(new Chicken("Kevin")) }
            };
            //foreach (DictionaryEntry myEntry in animalCollection)
            //{
            //    ((Animal)myEntry.Value).Feed();
            //    WriteLine(((Animal)myEntry.Value).Name);
            //}
            foreach(Animal myAnimal in animalCollection)
            {
                WriteLine($"New {myAnimal.ToString()} object added to " +
                    $"custom collection, Name = {myAnimal.Name}");
            }
            ReadKey();
        }
    }
}
