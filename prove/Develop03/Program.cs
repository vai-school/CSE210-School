using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("How many words do you want to vanish each time? ");
        int Amount = int.Parse(Console.ReadLine());
        
        Scripture Scripture = new Scripture(
            "Jacob 2:18-19",
            "18 But before ye seek for riches, seek ye for the kingdom of God. 19 And after ye have obtained a hope in Christ ye shall obtain riches, if ye seek them; and ye will seek them for the intent to do good—to clothe the naked, and to feed the hungry, and to liberate the captive, and administer relief to the sick and the afflicted."
        );

        Scripture.DisplayVerse();

        while (true)
        {
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit:");
            string Input = Console.ReadLine();

            if (Input.ToLower() == "quit")
            {
                break;
            }

            Scripture.HideWords(Amount);
            
            if (Scripture.AllHidden())
            {
                break;
            }
        }
    }
}