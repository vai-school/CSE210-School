using System;
class Prompt
{   
    private List<string> _prompts = new List<string>();

    public string GetPrompt()
    {
        _prompts = new List<string>(); 
        
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");

        var rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
