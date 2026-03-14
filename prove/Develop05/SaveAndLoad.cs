using System;
using System.Collections.Generic;
using System.IO;

class SaveAndLoad
{
    private string _filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Goal.txt");

    public void SaveGoals(List<Goal> goals, int score)
    {
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            outputFile.WriteLine(score);
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.GetSaveString());
            }
        }
        Console.WriteLine("Goals saved.\n");
    }

    public void LoadGoals(List<Goal> goals, ref int score)
    {
        if (!File.Exists(_filename))
        {
            Console.WriteLine("No saved file found.\n");
            return;
        }

        goals.Clear();
        using (StreamReader inputFile = new StreamReader(_filename))
        {
            score = int.Parse(inputFile.ReadLine());
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                string[] parts = line.Split('~');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    SimpleGoal g = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4]))
                        g.RecordEvent();
                    goals.Add(g);
                }
                else if (type == "EternalGoal")
                {
                    goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (type == "ChecklistGoal")
                {
                    ChecklistGoal g = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                    int timesCompleted = int.Parse(parts[6]);
                    for (int i = 0; i < timesCompleted; i++)
                        g.RecordEvent();
                    goals.Add(g);
                }
            }
        }
        Console.WriteLine("Goals loaded.\n");
    }
}