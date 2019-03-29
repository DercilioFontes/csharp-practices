using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch05Ex02
{
    enum orientation : byte
    {
        north = 1,
        south = 2,
        east = 3,
        west = 4
    }
    class Program
    {
        static void Main(string[] args)
        {
            byte directionByte;
            string directionString;
     
            orientation myDirection = orientation.north;
            WriteLine($"myDirection = {myDirection}");

            directionByte = (byte)myDirection;
            directionString = Convert.ToString(myDirection); // Or
            directionString = myDirection.ToString();

            WriteLine($"byte equivalent = {directionByte}");
            WriteLine($"string equivalent = {directionString}");

            myDirection = (orientation)3;
            WriteLine($"byte -> orientation type: 3 -> {myDirection}");

            directionString = "west";

            myDirection = (orientation)Enum.Parse(typeof(orientation), directionString);
            WriteLine($"string -> orientation type: \"west\" -> {myDirection}");
            ReadKey();
        }
    }
}
