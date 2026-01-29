using System;

public class Entry
{
    public string Prompt;
    public string Response;
    public string Date;
    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        Date = dateText;
    }

    public override string ToString()
    {
        return $"Date: {Date} - Prompt: {Prompt}\n{Response}";
    }
}