using System;

namespace Ch03Ex02
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double firstNumber, secondNumber;
            string userName;
            Console.WriteLine("Enter your name:");
            userName = Console.ReadLine();
            Console.WriteLine($"Welcome {userName}!");
            Console.WriteLine("Now give me a number:");
            firstNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Now give me another number:");
            secondNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"The sum of {firstNumber} and {secondNumber} is " + $"{firstNumber + secondNumber}.");
            Console.WriteLine($"The result of subtracting {firstNumber} from {secondNumber} is " + $"{firstNumber - secondNumber}.");
            Console.WriteLine($"The procuct of {firstNumber} and {secondNumber} is " + $"{firstNumber * secondNumber}.");
            Console.WriteLine($"The result of dividing {firstNumber} by {secondNumber} is " + $"{firstNumber / secondNumber}.");
            Console.WriteLine($"The remainder after diving {firstNumber} by {secondNumber} is " + $"{firstNumber % secondNumber}.");
            Console.ReadKey();
        }
    }
}
