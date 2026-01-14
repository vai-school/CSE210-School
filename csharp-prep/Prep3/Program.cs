using System;

class Program
{
    static void Main(string[] args)
    {
        int magic;
        int guess;

    

        Random randomGenerator = new Random();
        magic = randomGenerator.Next(1, 100);

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