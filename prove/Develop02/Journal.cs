using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Journal.txt");


    public void AddEntry(string prompt, string response)
    {
        Entry newEntry = new Entry(prompt, response);
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        Console.WriteLine("Journal Entries:");
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine();
        }
    }

    public void SaveEntries()
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                outputFile.WriteLine($"{entry.Date}~{entry.Prompt}~{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved.\n");
    }
    public void LoadEntries()
    {
        if (File.Exists(filename))
        {
            entries.Clear();
            using (StreamReader inputFile = new StreamReader(filename))
            {
                string line;
                while ((line = inputFile.ReadLine()) != null)
                {
                    string[] parts = line.Split('~');
                    Entry entry = new Entry(parts[1], parts[2]);
                    entry.Date = parts[0];
                    entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded.\n");
        }
        else
        {
            Console.WriteLine("No saved journal found.\n");
        }
    }
}