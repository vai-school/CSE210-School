using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> Scriptures = new List<Scripture>();
        
        Scriptures.Add(new Scripture(
            "Jacob 2:18-19",
            "18 But before ye seek for riches, seek ye for the kingdom of God. 19 And after ye have obtained a hope in Christ ye shall obtain riches, if ye seek them; and ye will seek them for the intent to do good—to clothe the naked, and to feed the hungry, and to liberate the captive, and administer relief to the sick and the afflicted."
        ));
        
        Scriptures.Add(new Scripture(
            "Alma 32:21",
            "21 And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."
        ));
        
        Scriptures.Add(new Scripture(
            "Mosiah 2:17",
            "17 And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."
        ));
        
        Random Random = new Random();
        int RandomIndex = Random.Next(0, Scriptures.Count);
        Scripture Scripture = Scriptures[RandomIndex];
        
        Console.Write("How many words do you want to vanish each time? ");
        int Amount = int.Parse(Console.ReadLine());

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