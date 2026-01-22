using System;

class Program
{
    static void Main(string[] args)
        {
            DisplayWelcome();

            string username = PromptUserName();
            int favoriteNumber = PromptUserNumber();

            int birthYear;
            PromtUserBirthYear(out birthYear);

            int squaredNumber = SquareNumber(favoriteNumber);

            DisplayResult(username, squaredNumber, birthYear);
        }

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        static void PromtUserBirthYear(out int birthYear)
        {
            Console.Write("Please enter your birth year: ");
            birthYear = int.Parse(Console.ReadLine());
        }

        static int SquareNumber(int number)
        {
            return number * number;
        }

        static void DisplayResult(string name, int squaredNumber, int birthYear)
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            Console.WriteLine();
            Console.WriteLine($"{name}, your favorite number squared is {squaredNumber}.");
            Console.WriteLine($"{name} You will turn {age} years old this year.");
        }
}