using System;

class Program
{
    static void Main(string[] args)
    {
        int magic;
        int guess;

    

        Console.Write("What's the magic number? ");
        magic = int.Parse(Console.ReadLine());

        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess > magic)
            {
                Console.WriteLine("Too high!");
            }
            else if (guess < magic)
            {
                Console.WriteLine("Too low!");
            }
            else
            {
                Console.WriteLine("Correct!");
            }

        } while (guess != magic);

    
    }
}