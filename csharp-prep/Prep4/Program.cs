using System;

class Program
{
    static void Main(string[] args)
    {
        int number;
        List<int> numbers = new List<int>();

        do
        {
            Console.Write("Type a number (0 to quit): ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        int sum = 0;
        foreach (int i in numbers)
        {
            sum += i;
        }
        
        double average = (double)sum / numbers.Count;

        int max = numbers[0];
        foreach (int i in numbers)
        {
            if (i > max)
            {
                max = i;
            }
        }

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Max: {max}");
    }

}