using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobName = "Soda Shop Worker";
        job1._company = "Great Scotts";
        job1._startYear = 2022;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobName = "Food Runner";
        job2._company = "Texas RoadHouse";
        job2._startYear = 2020;
        job2._endYear = 2021;

        Resume myResume = new Resume();
        myResume._name = "Lunden V";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}

public class Job
{
    public string _jobName;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobName} ({_company}) {_startYear}-{_endYear}");
    }
}

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
