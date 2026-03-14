using System;

class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredTimes;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int requiredTimes, int bonus) : base(name, description, points)
    {
        _timesCompleted = 0;
        _requiredTimes = requiredTimes;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This goal is already complete!");
            return 0;
        }
        _timesCompleted++;
        if (_timesCompleted == _requiredTimes)
        {
            Console.WriteLine("Congrats! You finished the checklist goal! Bonus points earned!");
            return GetPoints() + _bonus;
        }
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _requiredTimes;
    }

    public override string GetDisplayString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {GetName()} ({GetDescription()}) -- Completed {_timesCompleted}/{_requiredTimes} times";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal~{GetName()}~{GetDescription()}~{GetPoints()}~{_requiredTimes}~{_bonus}~{_timesCompleted}";
    }
}