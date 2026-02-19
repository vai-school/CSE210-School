using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Michael", "Times Tables");
        Console.WriteLine(a1.GetSummary());
        MathAssignment a2 = new MathAssignment("Carson", "Long Division", "1", "1-3");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());
        WritingAssignment a3 = new WritingAssignment("John", "WW2", "How war affected Europe");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}