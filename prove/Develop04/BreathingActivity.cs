using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        StartMessage();

        int elapsedTime = 0;
        int breathSeconds = 4;
        bool inhaling = true;

        while (elapsedTime < GetDuration())
        {
            if (inhaling)
            {
                Console.Write("Breathe in...");
            }
            else
            {
                Console.Write("Breathe out...");
            }

            ShowCountdown(breathSeconds);
            elapsedTime += breathSeconds;
            inhaling = !inhaling;
        }

        EndMessage();
    }
}